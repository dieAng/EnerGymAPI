using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Ejercicios;
using EnerGymAPI.Core.Interfaces;
using EnerGymAPI.Domain.Entities;
using EnerGymAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnerGymAPI.Application.Services
{
    public class EjercicioService : IEjercicioService
    {
        private readonly EnerGymDbContext _context;

        public EjercicioService(EnerGymDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EjercicioResponseDto>> GetEjerciciosAsync()
        {
            return await _context.Ejercicios
                .Select(e => new EjercicioResponseDto
                {
                    Id = e.Id,
                    Nombre = e.Nombre,
                    GrupoMuscular = e.GrupoMuscular,
                    Equipo = e.Equipo,
                    Descripcion = e.Descripcion,
                    ImagenUrl = e.ImagenUrl,
                    VideoUrl = e.VideoUrl
                })
                .ToListAsync();
        }

        public async Task<EjercicioResponseDto> GetEjercicioByIdAsync(Guid id)
        {
            var ejercicio = await _context.Ejercicios.FindAsync(id);
            if (ejercicio == null) return null;

            return new EjercicioResponseDto
            {
                Id = ejercicio.Id,
                Nombre = ejercicio.Nombre,
                GrupoMuscular = ejercicio.GrupoMuscular,
                Equipo = ejercicio.Equipo,
                Descripcion = ejercicio.Descripcion,
                ImagenUrl = ejercicio.ImagenUrl,
                VideoUrl = ejercicio.VideoUrl
            };
        }

        public async Task<EjercicioResponseDto> CreateEjercicioAsync(EjercicioCreateRequestDto request)
        {
            var ejercicio = new Ejercicio
            {
                Nombre = request.Nombre,
                GrupoMuscular = request.GrupoMuscular,
                Equipo = request.Equipo,
                Descripcion = request.Descripcion,
                ImagenUrl = request.ImagenUrl,
                VideoUrl = request.VideoUrl
            };

            _context.Ejercicios.Add(ejercicio);
            await _context.SaveChangesAsync();

            return new EjercicioResponseDto
            {
                Id = ejercicio.Id,
                Nombre = ejercicio.Nombre,
                GrupoMuscular = ejercicio.GrupoMuscular,
                Equipo = ejercicio.Equipo,
                Descripcion = ejercicio.Descripcion,
                ImagenUrl = ejercicio.ImagenUrl,
                VideoUrl = ejercicio.VideoUrl
            };
        }
    }
}