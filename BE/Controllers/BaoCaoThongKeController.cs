using Microsoft.AspNetCore.Mvc;
using TLUScience.DTOs;

namespace TLUScience.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaoCaoThongKeController : ControllerBase
    {
        private readonly IBaoCaoThongKeService _baoCaoThongKeService;

        public BaoCaoThongKeController(IBaoCaoThongKeService baoCaoThongKeService)
        {
            _baoCaoThongKeService = baoCaoThongKeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddBaoCaoThongKeAsync([FromBody] BaoCaoThongKeCRUD baoCaoThongKe, int idNguoiLap)
        {
            var result = await _baoCaoThongKeService.AddBaoCaoThongKeAsync(baoCaoThongKe, idNguoiLap);

            if (result)
            {
                return Ok(new { message = "Thêm báo cáo thống kê thành công!" });
            }

            return BadRequest(new { message = "Thêm báo cáo thất bại, vui lòng thử lại!" });
        }

        [HttpGet("export-pdf/{id}")]
        public async Task<IActionResult> ExportBaoCaoToPdf(int id)
        {
            var fileContents = await _baoCaoThongKeService.ExportBaoCaoToPdfAsync(id);

            if (fileContents == null)
                return NotFound(new { message = "Không tìm thấy báo cáo" });

            return File(fileContents, "application/pdf", "BaoCaoThongKe.pdf");
        }

        [HttpGet("export-excel/{idBaoCao}")]
        public async Task<IActionResult> ExportBaoCaoToExcel(int idBaoCao)
        {
            var fileContent = await _baoCaoThongKeService.ExportBaoCaoToExcelAsync(idBaoCao);

            if (fileContent == null)
                return NotFound("Không tìm thấy báo cáo!");

            return File(fileContent, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"BaoCao_{idBaoCao}.xlsx");
        }

    }
}