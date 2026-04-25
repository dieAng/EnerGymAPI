using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Likes;
using EnerGymAPI.Core.Interfaces;
using EnerGymAPI.Domain.Entities;
using EnerGymAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnerGymAPI.Application.Services
{
    public class LikeService : ILikeService
    {
        private readonly EnerGymDbContext _context;

        public LikeService(EnerGymDbContext context)
        {
            _context = context;
        }

        public async Task<string> ToggleLikeAsync(LikeRequestDto request)
        {
            var likeExistente = await _context.LikePosts
                .FirstOrDefaultAsync(l => l.PostId == request.PostId && l.UsuarioId == request.UsuarioId);

            if (likeExistente != null)
            {
                _context.LikePosts.Remove(likeExistente);
                await _context.SaveChangesAsync();
                return "Like removido";
            }
            else
            {
                var nuevoLike = new LikePost
                {
                    PostId = request.PostId,
                    UsuarioId = request.UsuarioId
                };
                
                _context.LikePosts.Add(nuevoLike);
                await _context.SaveChangesAsync();
                return "Like agregado";
            }
        }
    }
}