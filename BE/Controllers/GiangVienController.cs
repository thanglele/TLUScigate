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

        [Authorize(Roles = "Ban quan ly")]
        [HttpGet]
        public async Task<ActionResult> GetFullGiangVienAsync()
        {
            var result = await _giangVienService.GetFullGiangVienAsync();
            return Ok(new { success = true, data = result });
        }

        [Authorize(Roles = "Ban quan ly")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetGiangvienAsync(int id)
        {
            var result = await _giangVienService.GetGiangVienAsync(id);
            if (result == null)
                return NotFound(new { success = false, message = "Không tìm thấy giảng viên" });
            
            return Ok(new { success = true, data = result });
        }

        [Authorize(Roles = "Ban quan ly")]
        [HttpPost]
        public async Task<ActionResult> AddGiangvienAsync([FromBody] GiangVienDTO giangvien)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _giangVienService.AddGiangVienAsync(giangvien);
            return Ok(new { success = result, 
                message = result ? "Thêm giảng viên thành công!" : "Thêm giảng viên thất bại!" 
            });
        }

        [Authorize(Roles = "Ban quan ly")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGiangvienAsync(int id, [FromBody] GiangVienDTO giangvien)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _giangVienService.UpdateGiangVienAsync(id, giangvien);
            return Ok(new { success = result, 
                message = result ? "Cập nhật giảng viên thành công!" : "Cập nhật giảng viên thất bại!" 
            });
        }

        [Authorize(Roles = "Ban quan ly")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteGiangvienAsync(int id)
        {
            var result = await _giangVienService.DeleteGiangVienAsync(id);
            return Ok(new { success = result, 
                message = result ? "Xóa giảng viên thành công!" : "Xóa giảng viên thất bại!" 
            });
        }
    }
}




