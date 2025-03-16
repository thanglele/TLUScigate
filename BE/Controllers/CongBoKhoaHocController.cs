using Microsoft.AspNetCore.Mvc;
using TLUScience.DTOs;

namespace TLUScience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CongBoKhoaHocController : ControllerBase
    {
        private readonly ICongBoKhoaHocService _congBoKhoaHocService;

        public CongBoKhoaHocController(ICongBoKhoaHocService congBoKhoaHocService)
        {
            _congBoKhoaHocService = congBoKhoaHocService;
        }

        [HttpGet]
        public async Task<ActionResult> GetFullCongBoKhoaHocAsync()
        {
            var congbo = await _congBoKhoaHocService.GetFullCongBoKhoaHocAsync();
            return Ok(congbo);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetCongBoKhoaHocAsync(int id)
        {
            var congbo = await _congBoKhoaHocService.GetCongBoKhoaHocAsync(id);
            return Ok(congbo);
        }

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