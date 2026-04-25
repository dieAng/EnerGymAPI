using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Usuarios;
using EnerGymAPI.Core.Interfaces;
using EnerGymAPI.Domain.Entities;
using EnerGymAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnerGymAPI.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly EnerGymDbContext _context;

        public UsuarioService(EnerGymDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<UsuarioResponseDto>> GetUsuariosAsync()
        {
            return await _context.Usuarios
                .Select(u => new UsuarioResponseDto
                {
                    Id = u.Id,
                    Nombre = u.Nombre,
                    Email = u.Email,
                    Edad = u.Edad,
                    Peso = u.Peso,
                    Altura = u.Altura,
                    Objetivo = u.Objetivo,
                    FotoUrl = u.FotoUrl,
                    Rol = u.Rol
                })
                .ToListAsync();
        }

        public async Task<UsuarioResponseDto> GetUsuarioByIdAsync(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null) return null;

            return new UsuarioResponseDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Edad = usuario.Edad,
                Peso = usuario.Peso,
                Altura = usuario.Altura,
                Objetivo = usuario.Objetivo,
                FotoUrl = usuario.FotoUrl,
                Rol = usuario.Rol
            };
        }

        public async Task<UsuarioResponseDto> CreateUsuarioAsync(UsuarioCreateRequestDto requestDto)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(requestDto.Password);

            var nuevoUsuario = new Usuario
            {
                Nombre = requestDto.Nombre,
                Email = requestDto.Email,
                PasswordHash = passwordHash,
                Edad = requestDto.Edad,
                Peso = requestDto.Peso,
                Altura = requestDto.Altura,
                Objetivo = requestDto.Objetivo,
                FotoUrl = requestDto.FotoUrl,
                Rol = "usuario"
            };

            _context.Usuarios.Add(nuevoUsuario);
            await _context.SaveChangesAsync();

            return new UsuarioResponseDto
            {
                Id = nuevoUsuario.Id,
                Nombre = nuevoUsuario.Nombre,
                Email = nuevoUsuario.Email,
                Edad = nuevoUsuario.Edad,
                Peso = nuevoUsuario.Peso,
                Altura = nuevoUsuario.Altura,
                Objetivo = nuevoUsuario.Objetivo,
                FotoUrl = nuevoUsuario.FotoUrl,
                Rol = nuevoUsuario.Rol
            };
        }

        public async Task<UsuarioResponseDto> UpdateUsuarioAsync(Guid id, UsuarioUpdateRequestDto requestDto)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null) return null;

            if (requestDto.Nombre != null) usuario.Nombre = requestDto.Nombre;
            if (requestDto.Edad.HasValue) usuario.Edad = requestDto.Edad;
            if (requestDto.Peso.HasValue) usuario.Peso = requestDto.Peso;
            if (requestDto.Altura.HasValue) usuario.Altura = requestDto.Altura;
            if (requestDto.Objetivo != null) usuario.Objetivo = requestDto.Objetivo;
            if (requestDto.FotoUrl != null) usuario.FotoUrl = requestDto.FotoUrl;

            await _context.SaveChangesAsync();

            return new UsuarioResponseDto
            {
                Id = usuario.Id,
                Nombre = usuario.Nombre,
                Email = usuario.Email,
                Edad = usuario.Edad,
                Peso = usuario.Peso,
                Altura = usuario.Altura,
                Objetivo = usuario.Objetivo,
                FotoUrl = usuario.FotoUrl,
                Rol = usuario.Rol
            };
        }

        public async Task<bool> DeleteUsuarioAsync(Guid id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null) return false;

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}