using System.Threading.Tasks;
using EnerGymAPI.Application.DTO.Likes;
using EnerGymAPI.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EnerGymAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService _likeService;

        public LikeController(ILikeService likeService)
        {
            _likeService = likeService;
        }

        [HttpPost]
        public async Task<IActionResult> ToggleLike(LikeRequestDto request)
        {
            var message = await _likeService.ToggleLikeAsync(request);
            return Ok(new { message });
        }
    }
}