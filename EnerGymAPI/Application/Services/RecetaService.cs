using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Recetas;
using EnerGymAPI.Core.Interfaces;
using EnerGymAPI.Domain.Entities;
using EnerGymAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnerGymAPI.Application.Services
{
    public class RecetaService : IRecetaService
    {
        private readonly EnerGymDbContext _context;

        public RecetaService(EnerGymDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RecetaResponseDto>> GetRecetasAsync()
        {
            return await _context.Recetas
                .Select(r => new RecetaResponseDto
                {
                    Id = r.Id,
                    UsuarioId = r.UsuarioId,
                    Nombre = r.Nombre,
                    TiempoPreparacion = r.TiempoPreparacion,
                    Alergenos = r.Alergenos,
                    ImagenUrl = r.ImagenUrl,
                    Descripcion = r.Descripcion,
                    EsPredisenada = r.EsPredisenada
                })
                .ToListAsync();
        }

        public async Task<RecetaResponseDto> GetRecetaByIdAsync(Guid id)
        {
            var receta = await _context.Recetas.FindAsync(id);
            if (receta == null) return null;

            return new RecetaResponseDto
            {
                Id = receta.Id,
                UsuarioId = receta.UsuarioId,
                Nombre = receta.Nombre,
                TiempoPreparacion = receta.TiempoPreparacion,
                Alergenos = receta.Alergenos,
                ImagenUrl = receta.ImagenUrl,
                Descripcion = receta.Descripcion,
                EsPredisenada = receta.EsPredisenada
            };
        }

        public async Task<RecetaResponseDto> CreateRecetaAsync(RecetaCreateRequestDto request)
        {
            var receta = new Receta
            {
                UsuarioId = request.UsuarioId,
                Nombre = request.Nombre,
                TiempoPreparacion = request.TiempoPreparacion,
                Alergenos = request.Alergenos,
                ImagenUrl = request.ImagenUrl,
                Descripcion = request.Descripcion,
                EsPredisenada = request.EsPredisenada
            };

            _context.Recetas.Add(receta);
            await _context.SaveChangesAsync();

            return new RecetaResponseDto
            {
                Id = receta.Id,
                UsuarioId = receta.UsuarioId,
                Nombre = receta.Nombre,
                TiempoPreparacion = receta.TiempoPreparacion,
                Alergenos = receta.Alergenos,
                ImagenUrl = receta.ImagenUrl,
                Descripcion = receta.Descripcion,
                EsPredisenada = receta.EsPredisenada
            };
        }

        public async Task<bool> DeleteRecetaAsync(Guid id)
        {
            var receta = await _context.Recetas.FindAsync(id);
            if (receta == null) return false;

            _context.Recetas.Remove(receta);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}