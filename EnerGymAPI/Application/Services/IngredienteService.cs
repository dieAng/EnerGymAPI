using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Ingredientes;
using EnerGymAPI.Core.Interfaces;
using EnerGymAPI.Domain.Entities;
using EnerGymAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnerGymAPI.Application.Services
{
    public class IngredienteService : IIngredienteService
    {
        private readonly EnerGymDbContext _context;

        public IngredienteService(EnerGymDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<IngredienteResponseDto>> GetIngredientesAsync()
        {
            return await _context.Ingredientes
                .Select(i => new IngredienteResponseDto
                {
                    Id = i.Id,
                    Nombre = i.Nombre,
                    Calorias = i.Calorias,
                    Proteinas = i.Proteinas,
                    Carbohidratos = i.Carbohidratos,
                    Grasas = i.Grasas
                })
                .ToListAsync();
        }

        public async Task<IngredienteResponseDto> CreateIngredienteAsync(IngredienteCreateRequestDto request)
        {
            var ingrediente = new Ingrediente
            {
                Nombre = request.Nombre,
                Calorias = request.Calorias,
                Proteinas = request.Proteinas,
                Carbohidratos = request.Carbohidratos,
                Grasas = request.Grasas
            };

            _context.Ingredientes.Add(ingrediente);
            await _context.SaveChangesAsync();

            return new IngredienteResponseDto
            {
                Id = ingrediente.Id,
                Nombre = ingrediente.Nombre,
                Calorias = ingrediente.Calorias,
                Proteinas = ingrediente.Proteinas,
                Carbohidratos = ingrediente.Carbohidratos,
                Grasas = ingrediente.Grasas
            };
        }
    }
}