using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Posts;

namespace EnerGymAPI.Core.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<PostResponseDto>> GetPostsAsync();
        Task<PostResponseDto> GetPostByIdAsync(Guid id);
        Task<PostResponseDto> CreatePostAsync(PostCreateRequestDto request);
        Task<bool> DeletePostAsync(Guid id);
    }
}