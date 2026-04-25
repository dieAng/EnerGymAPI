using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Posts;
using EnerGymAPI.Core.Interfaces;
using EnerGymAPI.Domain.Entities;
using EnerGymAPI.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EnerGymAPI.Application.Services
{
    public class PostService : IPostService
    {
        private readonly EnerGymDbContext _context;

        public PostService(EnerGymDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<PostResponseDto>> GetPostsAsync()
        {
            return await _context.Posts
                .Select(p => new PostResponseDto
                {
                    Id = p.Id,
                    UsuarioId = p.UsuarioId,
                    Contenido = p.Contenido,
                    ImagenUrl = p.ImagenUrl,
                    EnergiaGenerada = p.EnergiaGenerada,
                    Fecha = p.Fecha
                })
                .ToListAsync();
        }

        public async Task<PostResponseDto> GetPostByIdAsync(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return null;

            return new PostResponseDto
            {
                Id = post.Id,
                UsuarioId = post.UsuarioId,
                Contenido = post.Contenido,
                ImagenUrl = post.ImagenUrl,
                EnergiaGenerada = post.EnergiaGenerada,
                Fecha = post.Fecha
            };
        }

        public async Task<PostResponseDto> CreatePostAsync(PostCreateRequestDto request)
        {
            var post = new Post
            {
                UsuarioId = request.UsuarioId,
                Contenido = request.Contenido,
                ImagenUrl = request.ImagenUrl,
                EnergiaGenerada = request.EnergiaGenerada,
                Fecha = request.Fecha == 0 ? DateTimeOffset.UtcNow.ToUnixTimeMilliseconds() : request.Fecha
            };

            _context.Posts.Add(post);
            await _context.SaveChangesAsync();

            return new PostResponseDto
            {
                Id = post.Id,
                UsuarioId = post.UsuarioId,
                Contenido = post.Contenido,
                ImagenUrl = post.ImagenUrl,
                EnergiaGenerada = post.EnergiaGenerada,
                Fecha = post.Fecha
            };
        }

        public async Task<bool> DeletePostAsync(Guid id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null) return false;

            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}