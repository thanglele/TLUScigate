using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TLUScience.DTOs;

namespace TLUScience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NCKHSinhVienController : ControllerBase
    {
        private readonly INCKHSinhVienService _nckhSinhVienService;

        public NCKHSinhVienController(INCKHSinhVienService nckhSinhVienService)
        {
            _nckhSinhVienService = nckhSinhVienService;
        }

        [HttpGet]
        public async Task<ActionResult> GetFullNCKHSinhVienAsync()
        {
            return Ok(await _nckhSinhVienService.GetFullNCKHSinhVienAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetNCKHSinhVienAsync(int id)
        {
            return Ok(await _nckhSinhVienService.GetNCKHSinhVienAsync(id));
        }

        [HttpPost]
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
        public async Task<ActionResult> UpdateNCKHSinhVienAsync(int id, [FromBody] NCKHSinhVienCRUD nCKHSinhVien)
        {
            var result = await _nckhSinhVienService.UpdateNCKHSinhVienAsync(id, nCKHSinhVien);
            if (result)
            {
                return Ok(new { message = "Cập nhật nghiên cứu khoa học sinh viên thành công!" });
            }
            return BadRequest(new { message = "Cập nhật nghiên cứu khoa học sinh viên thất bại, vui lòng thử lại!" });
        }

        [HttpDelete("{id}")]
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