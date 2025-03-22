using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TLUScience.DTOs;

namespace TLUScience.Controllers
{
    [Route("api/[controller]")]
    [ApiController] 
    [Authorize]
    public class CongBoKhoaHocController : ControllerBase
    {
        private readonly ICongBoKhoaHocService _congBoKhoaHocService;

        public CongBoKhoaHocController(ICongBoKhoaHocService congBoKhoaHocService)
        {
            _congBoKhoaHocService = congBoKhoaHocService;
        }

        [Authorize(Roles = "Ban quan ly, Giang vien")]
        [HttpGet]
        public async Task<ActionResult> GetFullCongBoKhoaHocAsync()
        {
            var congbo = await _congBoKhoaHocService.GetFullCongBoKhoaHocAsync();
            return Ok(congbo);
        }

        [Authorize(Roles = "Ban quan ly, Giang vien")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetCongBoKhoaHocAsync(int id)
        {
            var congbo = await _congBoKhoaHocService.GetCongBoKhoaHocAsync(id);
            return Ok(congbo);
        }

        [Authorize(Roles = "Giang vien")]
        [HttpPost]
        public async Task<ActionResult> AddCongBoKhoaHocAsync([FromBody] CongBoKhoaHocCRUD congBoKhoaHoc)
        {
            var result = await _congBoKhoaHocService.AddCongBoKhoaHocAsync(congBoKhoaHoc);
            if (result)
            {
                return Ok(new { message = "Thêm công bố khoa học thành công!" });
            }
            return BadRequest(new { message = "Thêm công bố khoa học thất bại, vui lòng thử lại!" });
        }

        [Authorize(Roles = "Giang vien")]
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCongBoKhoaHocAsync(int id, [FromBody] CongBoKhoaHocCRUD congBoKhoaHoc)
        {
            var result = await _congBoKhoaHocService.UpdateCongBoKhoaHocAsync(id, congBoKhoaHoc);
            if (result)
            {
                return Ok(new { message = "Cập nhật công bố khoa học thành công!" });
            }
            return BadRequest(new { message = "Cập nhật công bố khoa học thất bại, vui lòng thử lại!" });
        }

        [Authorize(Roles = "Ban quan ly")]
        [HttpPut("update-status/{id}")]
        public async Task<ActionResult> UpdateStatusCongBoKhoaHocAsync(int id, [FromBody] CBKHStatus status)
        {
            var result = await _congBoKhoaHocService.UpdateStatus(id, status);
            if (result)
            {
                return Ok(new { message = "Cập nhật trạng thái công bố khoa học thành công!" });
            }
            return BadRequest(new { message = "Cập nhật trạng thái công bố khoa học thất bại, vui lòng thử lại!" });
        }

        [Authorize(Roles = "Ban quan ly")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCongBoKhoaHocAsync(int id)
        {
            var result = await _congBoKhoaHocService.DeleteCongBoKhoaHocAsync(id);
            if (result)
            {
                return Ok(new { message = "Xóa công bố khoa học thành công!" });
            }
            return BadRequest(new { message = "Xóa công bố khoa học thất bại, vui lòng thử lại!" });
        }
    }
}