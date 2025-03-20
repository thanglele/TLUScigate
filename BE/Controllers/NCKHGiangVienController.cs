using Microsoft.AspNetCore.Mvc;
using TLUScience.DTOs;
using TLUScience.Services;

namespace TLUScience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NCKHGiangVienController : Controller
    {
        private readonly INCKHGiangVienService _nckhGiangVienService;

        public NCKHGiangVienController(INCKHGiangVienService nckhGiangVienService)
        {
            _nckhGiangVienService = nckhGiangVienService;
        }

        /// <summary>
        /// Lấy danh sách toàn bộ đề tài nghiên cứu
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _nckhGiangVienService.GetFullNCKHGiangVienAsync();
            return Ok(result);
        }

        /// <summary>
        /// Lấy thông tin một đề tài nghiên cứu theo ID
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _nckhGiangVienService.GetNCKHGiangVienAsync(id);
            if (result == null)
            {
                return NotFound(new { message = "Không tìm thấy đề tài nghiên cứu!" });
            }
            return Ok(result);
        }

        /// <summary>
        /// Thêm mới một đề tài nghiên cứu
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NCKHGiangVienDTO model)
        {
            if (model == null)
            {
                return BadRequest(new { message = "Dữ liệu đầu vào không hợp lệ!" });
            }

            var isAdded = await _nckhGiangVienService.AddNCKHGiangVienAsync(model);
            if (!isAdded)
            {
                return StatusCode(500, new { message = "Lỗi khi thêm đề tài nghiên cứu!" });
            }

            return Ok(new { message = "Thêm thành công!" });
        }

        /// <summary>
        /// Cập nhật một đề tài nghiên cứu theo ID
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] NCKHGiangVienDTO model)
        {
            if (model == null)
            {
                return BadRequest(new { message = "Dữ liệu đầu vào không hợp lệ!" });
            }

            var isUpdated = await _nckhGiangVienService.UpdateNCKHGiangVienAsync(id, model);
            if (!isUpdated)
            {
                return NotFound(new { message = "Không tìm thấy đề tài nghiên cứu để cập nhật!" });
            }

            return Ok(new { message = "Cập nhật thành công!" });
        }

        /// <summary>
        /// Xóa một đề tài nghiên cứu theo ID
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _nckhGiangVienService.DeleteNCKHGiangVienAsync(id);
            if (!isDeleted)
            {
                return NotFound(new { message = "Không tìm thấy đề tài nghiên cứu để xóa!" });
            }

            return Ok(new { message = "Xóa thành công!" });
        }
    }
}
