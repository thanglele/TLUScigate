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
            return Ok(await _giangVienService.GetFullGiangVienAsync());
        }

        [Authorize(Roles = "Ban quan ly")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetGiangvienAsync(int id)
        {
            return Ok(await _giangVienService.GetGiangVienAsync(id));
        }

        [Authorize(Roles = "Ban quan ly")]
        [HttpPost]
        public async Task<ActionResult> addGiangvienAsync([FromBody] GiangVienDTO giangvien)
        {
            var result = await _giangVienService.AddGiangVienAsync(giangvien);
            if (result)
            {
                return Ok(new { message = "Thêm tài khoản giảng viên thành công!" });
            }
            return BadRequest(new { message = "Thêm tài khoản giảng viên thất bại, vui lòng thử lại!" });
        }

        [Authorize(Roles = "Ban quan ly")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateGiangvienAsync(int id,[FromBody] GiangVienDTO giangvien)
        {
            var result = await _giangVienService.UpdateGiangVienAsync(id, giangvien);
            if (result)
            {
                return Ok(new { message = "Sửa tài khoản giảng viên thành công!" });
            }
            return BadRequest(new { message = "Sửa tài khoản giảng viên thất bại, vui lòng thử lại!" });
        }

        [Authorize(Roles = "Ban quan ly")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> RemoveGiangvienAsync(int id, [FromBody] GiangVienDTO giangvien)
        {
            var result = await _giangVienService.DeleteGiangVienAsync(id);
            if (result)
            {
                return Ok(new { message = "Xóa tài khoản giảng viên thành công!" });
            }
            return BadRequest(new { message = "Xóa tài khoản giảng viên thất bại, vui lòng thử lại!" });
        }
    }
}




