using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Rutinas;
using EnerGymAPI.Core.Interfaces;
using EnerGymAPI.Domain.Entities;
using EnerGymAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnerGymAPI.Application.Services
{
    public class RutinaService : IRutinaService
    {
        private readonly EnerGymDbContext _context;

        public RutinaService(EnerGymDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RutinaResponseDto>> GetRutinasAsync()
        {
            return await _context.Rutinas
                .Select(r => new RutinaResponseDto
                {
                    Id = r.Id,
                    UsuarioId = r.UsuarioId,
                    Nombre = r.Nombre,
                    Descripcion = r.Descripcion,
                    Nivel = r.Nivel,
                    Objetivo = r.Objetivo,
                    EsPredisenada = r.EsPredisenada
                })
                .ToListAsync();
        }

        public async Task<RutinaResponseDto> GetRutinaByIdAsync(Guid id)
        {
            var rutina = await _context.Rutinas.FindAsync(id);
            if (rutina == null) return null;

            return new RutinaResponseDto
            {
                Id = rutina.Id,
                UsuarioId = rutina.UsuarioId,
                Nombre = rutina.Nombre,
                Descripcion = rutina.Descripcion,
                Nivel = rutina.Nivel,
                Objetivo = rutina.Objetivo,
                EsPredisenada = rutina.EsPredisenada
            };
        }

        public async Task<RutinaResponseDto> CreateRutinaAsync(RutinaCreateRequestDto request)
        {
            var rutina = new Rutina
            {
                UsuarioId = request.UsuarioId,
                Nombre = request.Nombre,
                Descripcion = request.Descripcion,
                Nivel = request.Nivel,
                Objetivo = request.Objetivo,
                EsPredisenada = request.EsPredisenada
            };

            _context.Rutinas.Add(rutina);
            await _context.SaveChangesAsync();

            return new RutinaResponseDto
            {
                Id = rutina.Id,
                UsuarioId = rutina.UsuarioId,
                Nombre = rutina.Nombre,
                Descripcion = rutina.Descripcion,
                Nivel = rutina.Nivel,
                Objetivo = rutina.Objetivo,
                EsPredisenada = rutina.EsPredisenada
            };
        }

        public async Task<bool> DeleteRutinaAsync(Guid id)
        {
            var rutina = await _context.Rutinas.FindAsync(id);
            if (rutina == null) return false;

            _context.Rutinas.Remove(rutina);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}