using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TLUScience.DTOs;

namespace TLUScience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TapChiAnPhamController : ControllerBase
    {
        private readonly ITapChiAnPhamService _tapChiAnPhamService;

        public TapChiAnPhamController(ITapChiAnPhamService tapChiAnPhamService)
        {
            _tapChiAnPhamService = tapChiAnPhamService;
        }

        [HttpGet]
        [Authorize(Roles= "Ban quan ly, Giang vien")]
        public async Task<IActionResult> GetFullTapChiAnPhamAsync()
        {
            var tapChiAnPhams = await _tapChiAnPhamService.GetFullTapChiAnPhamAsync();
            return Ok(tapChiAnPhams);
        }

        [HttpGet("{id}")]
        [Authorize(Roles= "Ban quan ly, Giang vien")]
        public async Task<IActionResult> GetTapChiAnPhamAsync(int id)
        {
            var tapChiAnPham = await _tapChiAnPhamService.GetTapChiAnPhamAsync(id);
            return Ok(tapChiAnPham);
        }

        [HttpPost]
        [Authorize(Roles= "Giang vien")]
        public async Task<IActionResult> AddTapChiAnPhamAsync([FromBody] TapChiAnPhamCRUD tapChiAnPham, string maGiangVien)
        {
            var result = await _tapChiAnPhamService.AddTapChiAnPhamAsync(tapChiAnPham, maGiangVien);
            if(result)
            {
                return Ok(new { message = "Thêm tạp chí ấn phẩm thành công!" });
            }
            return BadRequest(new { message = "Thêm tạp chí ấn phẩm thất bại, vui lòng thử lại!" });
        }

        [HttpPut("{id}")]
        [Authorize(Roles= "Giang vien")]
        public async Task<IActionResult> UpdateTapChiAnPhamAsync(int id, [FromBody] TapChiAnPhamCRUD tapChiAnPham, string maGiangVien)
        {
            var result = await _tapChiAnPhamService.UpdateTapChiAnPhamAsync(id, tapChiAnPham, maGiangVien);
            if(result)
            {
                return Ok(new { message = "Cập nhật tạp chí ấn phẩm thành công!" });
            }
            return BadRequest(new { message = "Cập nhật tạp chí ấn phẩm thất bại, vui lòng thử lại!" });
        }

        [HttpPut("update-status/{id}")]
        [Authorize(Roles= "Ban quan ly")]

        public async Task<IActionResult> UpdateStatusTapChiAnPhamAsync(int id, [FromBody] TCAPStatus status)
        {
            var result = await _tapChiAnPhamService.UpdateStatus(id, status);
            if(result)
            {
                return Ok(new { message = "Cập nhật trạng thái tạp chí ấn phẩm thành công!" });
            }
            return BadRequest(new { message = "Cập nhật trạng thái tạp chí ấn phẩm thất bại, vui lòng thử lại!" });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles= "Ban quan ly")]
        public async Task<IActionResult> DeleteTapChiAnPhamAsync(int id)
        {
            var result = await _tapChiAnPhamService.DeleteTapChiAnPhamAsync(id);
            if(result)
            {
                return Ok(new { message = "Xóa tạp chí ấn phẩm thành công!" });
            }
            return BadRequest(new { message = "Xóa tạp chí ấn phẩm thất bại, vui lòng thử lại!" });
        }
    }
}