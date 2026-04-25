using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Likes;

namespace EnerGymAPI.Core.Interfaces
{
    public interface ILikeService
    {
        Task<string> ToggleLikeAsync(LikeRequestDto request);
    }
}