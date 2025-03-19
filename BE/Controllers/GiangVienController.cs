using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TLUScience.DTOs;

namespace TLUScience.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class GiangVienController : ControllerBase
    {
        private readonly IGiangVienService _giangVienService;

        public GiangVienController(IGiangVienService giangVienService)
        {
            _giangVienService = giangVienService;
        }

        [HttpGet]
        public async Task<ActionResult<List<GiangVienDTO>>> GetFullGiangVienAsync()
        {
            return await _giangVienService.GetFullGiangVienAsync();
        }

        [HttpPost]
        public async Task<ActionResult> addGiangvienAsync()
        {

        }
    }

}




