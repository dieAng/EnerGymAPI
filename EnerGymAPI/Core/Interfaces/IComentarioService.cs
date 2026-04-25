using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Comentarios;

namespace EnerGymAPI.Core.Interfaces
{
    public interface IComentarioService
    {
        Task<IEnumerable<ComentarioResponseDto>> GetComentariosPorPostAsync(Guid postId);
        Task<ComentarioResponseDto> CreateComentarioAsync(ComentarioCreateRequestDto request);
        Task<bool> DeleteComentarioAsync(Guid id);
    }
}