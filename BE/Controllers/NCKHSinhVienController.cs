using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TLUScience.DTOs;

namespace TLUScience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NCKHSinhVienController : ControllerBase
    {
        private readonly INCKHSinhVienService _nckhSinhVienService;

        public NCKHSinhVienController(INCKHSinhVienService nckhSinhVienService)
        {
            _nckhSinhVienService = nckhSinhVienService;
        }

        [HttpGet]
        [Authorize(Roles= "Ban quan ly, Giang vien")]
        public async Task<ActionResult> GetFullNCKHSinhVienAsync()
        {
            return Ok(await _nckhSinhVienService.GetFullNCKHSinhVienAsync());
        }

        [HttpGet("{id}")]
        [Authorize(Roles= "Ban quan ly, Giang vien")]
        public async Task<ActionResult> GetNCKHSinhVienAsync(int id)
        {
            return Ok(await _nckhSinhVienService.GetNCKHSinhVienAsync(id));
        }

        [HttpPost]
        [Authorize(Roles= "Giang vien")]

        public async Task<ActionResult> AddNCKHSinhVienAsync([FromBody] NCKHSinhVienCRUD nCKHSinhVien)
        {
            var result = await _nckhSinhVienService.AddNCKHSinhVienAsync(nCKHSinhVien);
            if (result)
            {
                return Ok(new { message = "Thêm nghiên cứu khoa học sinh viên thành công!" });
            }
            return BadRequest(new { message = "Thêm nghiên cứu khoa học sinh viên thất bại, vui lòng thử lại!" });
        }

        [HttpPut("{id}")]
        [Authorize(Roles= "Giang vien")]
        public async Task<ActionResult> UpdateNCKHSinhVienAsync(int id, [FromBody] NCKHSinhVienCRUD nCKHSinhVien)
        {
            var result = await _nckhSinhVienService.UpdateNCKHSinhVienAsync(id, nCKHSinhVien);
            if (result)
            {
                return Ok(new { message = "Cập nhật nghiên cứu khoa học sinh viên thành công!" });
            }
            return BadRequest(new { message = "Cập nhật nghiên cứu khoa học sinh viên thất bại, vui lòng thử lại!" });
        }

        [Authorize(Roles= "Ban quan ly")]
        [HttpPut("update-status/{id}")]
        public async Task<ActionResult> UpdateStatusNCKHSinhVienAsync(int id, [FromBody] Status status)
        {
            var result = await _nckhSinhVienService.UpdateStatus(id, status);
            if (result)
            {
                return Ok(new { message = "Cập nhật trạng thái nghiên cứu khoa học sinh viên thành công!" });
            }
            return BadRequest(new { message = "Cập nhật trạng thái nghiên cứu khoa học sinh viên thất bại, vui lòng thử lại!" });
        } 

        [HttpDelete("{id}")]
        [Authorize(Roles= "Ban quan ly")]
        public async Task<ActionResult> DeleteNCKHSinhVienAsync(int id)
        {
            var result = await _nckhSinhVienService.DeleteNCKHSinhVienAsync(id);
            if (result)
            {
                return Ok(new { message = "Xóa nghiên cứu khoa học sinh viên thành công!" });
            }
            return BadRequest(new { message = "Xóa nghiên cứu khoa học sinh viên thất bại, vui lòng thử lại!" });
        }
    }



}