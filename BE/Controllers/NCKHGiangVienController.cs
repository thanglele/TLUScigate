using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TLUScience.DTOs;
using TLUScience.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TLUScience.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NCKHGiangVienController : ControllerBase
    {
        private readonly INCKHGiangVienService _nckhGiangVienService;
        private readonly ILogger<NCKHGiangVienController> _logger;

        public NCKHGiangVienController(
            INCKHGiangVienService nckhGiangVienService,
            ILogger<NCKHGiangVienController> logger)
        {
            _nckhGiangVienService = nckhGiangVienService;
            _logger = logger;
        }

        /// <summary>
        /// Lấy danh sách toàn bộ đề tài nghiên cứu khoa học của giảng viên
        /// </summary>
        [Authorize(Roles = "Ban quan ly,Giang vien")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NCKHGiangVienDTO>>> GetAll()
        {
            try
            {
                var result = await _nckhGiangVienService.GetFullNCKHGiangVienAsync();
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách đề tài NCKH");
                return StatusCode(500, new { 
                    success = false, 
                    message = "Đã xảy ra lỗi khi lấy danh sách đề tài nghiên cứu"
                });
            }
        }

        /// <summary>
        /// Lấy thông tin một đề tài nghiên cứu theo ID
        /// </summary>
        [Authorize(Roles = "Ban quan ly,Giang vien")]
        [HttpGet("{id}")]
        public async Task<ActionResult<NCKHGiangVienDTO>> GetById(int id)
        {
            try
            {
                var result = await _nckhGiangVienService.GetNCKHGiangVienAsync(id);
                if (result == null)
                {
                    return NotFound(new { 
                        success = false, 
                        message = $"Không tìm thấy đề tài nghiên cứu với ID: {id}"
                    });
                }
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi lấy đề tài NCKH với ID={id}");
                return StatusCode(500, new { 
                    success = false, 
                    message = "Đã xảy ra lỗi khi lấy thông tin đề tài nghiên cứu"
                });
            }
        }

        /// <summary>
        /// Thêm mới một đề tài nghiên cứu
        /// </summary>
        [Authorize(Roles = "Ban quan ly,Giang vien")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] NCKHGiangVienDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { 
                        success = false, 
                        message = "Dữ liệu không hợp lệ",
                        errors = ModelState.Values.SelectMany(v => v.Errors)
                    });
                }

                var isSuccess = await _nckhGiangVienService.AddNCKHGiangVienAsync(model);
                if (!isSuccess)
                {
                    return BadRequest(new { 
                        success = false, 
                        message = "Không thể thêm đề tài nghiên cứu"
                    });
                }

                return Ok(new { 
                    success = true, 
                    message = "Thêm đề tài nghiên cứu thành công"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi thêm đề tài NCKH");
                return StatusCode(500, new { 
                    success = false, 
                    message = "Đã xảy ra lỗi khi thêm đề tài nghiên cứu"
                });
            }
        }

        /// <summary>
        /// Cập nhật một đề tài nghiên cứu theo ID
        /// </summary>
        [Authorize(Roles = "Ban quan ly,Giang vien")]
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] NCKHGiangVienDTO model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new { 
                        success = false, 
                        message = "Dữ liệu không hợp lệ",
                        errors = ModelState.Values.SelectMany(v => v.Errors)
                    });
                }

                var isSuccess = await _nckhGiangVienService.UpdateNCKHGiangVienAsync(id, model);
                if (!isSuccess)
                {
                    return NotFound(new { 
                        success = false, 
                        message = $"Không tìm thấy đề tài nghiên cứu với ID: {id}"
                    });
                }

                return Ok(new { 
                    success = true, 
                    message = "Cập nhật đề tài nghiên cứu thành công"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi cập nhật đề tài NCKH với ID={id}");
                return StatusCode(500, new { 
                    success = false, 
                    message = "Đã xảy ra lỗi khi cập nhật đề tài nghiên cứu"
                });
            }
        }

        /// <summary>
        /// Xóa một đề tài nghiên cứu theo ID
        /// </summary>
        [Authorize(Roles = "Ban quan ly")]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var isSuccess = await _nckhGiangVienService.DeleteNCKHGiangVienAsync(id);
                if (!isSuccess)
                {
                    return NotFound(new { 
                        success = false, 
                        message = $"Không tìm thấy đề tài nghiên cứu với ID: {id}"
                    });
                }

                return Ok(new { 
                    success = true, 
                    message = "Xóa đề tài nghiên cứu thành công"
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi xóa đề tài NCKH với ID={id}");
                return StatusCode(500, new { 
                    success = false, 
                    message = "Đã xảy ra lỗi khi xóa đề tài nghiên cứu"
                });
            }
        }
    }
}
