using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Mensajes;

namespace EnerGymAPI.Core.Interfaces
{
    public interface IMensajeService
    {
        Task<IEnumerable<MensajeResponseDto>> GetMensajesAsync(Guid usuarioId1, Guid usuarioId2);
        Task<MensajeResponseDto> CreateMensajeAsync(MensajeCreateRequestDto request);
    }
}