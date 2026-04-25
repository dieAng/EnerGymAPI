using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Usuarios;
using EnerGymAPI.Domain.Entities;

namespace EnerGymAPI.Core.Interfaces
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioResponseDto>> GetUsuariosAsync();
        Task<UsuarioResponseDto> GetUsuarioByIdAsync(Guid id);
        Task<UsuarioResponseDto> CreateUsuarioAsync(UsuarioCreateRequestDto requestDto);
        Task<UsuarioResponseDto> UpdateUsuarioAsync(Guid id, UsuarioUpdateRequestDto requestDto);
        Task<bool> DeleteUsuarioAsync(Guid id);
    }
}