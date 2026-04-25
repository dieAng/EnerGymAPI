using EnerGymAPI.Application.DTO.Auth;
using EnerGymAPI.Application.Services;
using EnerGymAPI.Domain.Entities;
using EnerGymAPI.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace EnerGymAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly EnerGymDbContext _context;
        private readonly TokenService _tokenService;
        private readonly IConfiguration _configuration;

        public AuthController(EnerGymDbContext context, TokenService tokenService, IConfiguration configuration)
        {
            _context = context;
            _tokenService = tokenService;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login(LoginRequestDto request)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(request.Password, usuario.PasswordHash))
            {
                return Unauthorized(new { message = "Credenciales incorrectas" });
            }

            // Generamos el Token real usando el TokenService
            var accessToken = _tokenService.GenerarTokenAcceso(usuario);
            var refreshToken = _tokenService.GenerarRefreshToken();

            // Guardar el refresh token en la base de datos
            var refreshTokenEntity = new RefreshToken
            {
                Token = refreshToken,
                UsuarioId = usuario.Id,
                ExpiryDate = DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration["Jwt:RefreshTokenExpireDays"]))
            };
            
            _context.RefreshTokens.Add(refreshTokenEntity);
            await _context.SaveChangesAsync();

            var response = new LoginResponseDto
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                UsuarioId = usuario.Id,
                Nombre = usuario.Nombre,
                Rol = usuario.Rol
            };

            return Ok(response);
        }

        [HttpPost("refresh")]
        public async Task<ActionResult<LoginResponseDto>> Refresh(RefreshTokenRequestDto request)
        {
            var storedToken = await _context.RefreshTokens
                .Include(rt => rt.Usuario)
                .FirstOrDefaultAsync(rt => rt.Token == request.RefreshToken);

            if (storedToken == null || storedToken.IsUsed || storedToken.IsRevoked || storedToken.ExpiryDate < DateTime.UtcNow)
            {
                return Unauthorized(new { message = "El refresh token no es válido o ha expirado" });
            }

            // Marcar el token actual como usado
            storedToken.IsUsed = true;
            
            // Generar un nuevo par de tokens
            var newAccessToken = _tokenService.GenerarTokenAcceso(storedToken.Usuario!);
            var newRefreshToken = _tokenService.GenerarRefreshToken();

            // Guardar el nuevo refresh token
            var newRefreshTokenEntity = new RefreshToken
            {
                Token = newRefreshToken,
                UsuarioId = storedToken.UsuarioId,
                ExpiryDate = DateTime.UtcNow.AddDays(Convert.ToDouble(_configuration["Jwt:RefreshTokenExpireDays"]))
            };

            _context.RefreshTokens.Add(newRefreshTokenEntity);
            await _context.SaveChangesAsync();

            return Ok(new LoginResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                UsuarioId = storedToken.UsuarioId,
                Nombre = storedToken.Usuario!.Nombre,
                Rol = storedToken.Usuario!.Rol
            });
        }
    }
}