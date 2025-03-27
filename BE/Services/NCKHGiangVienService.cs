using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkiaSharp;
using TLUScience.DTOs;
using TLUScience.Entities;
using TLUScience.Interface;
using TLUScience.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace TLUScience.Services
{
    public interface INCKHGiangVienService
    {
        Task<List<NCKHGiangVienDTO>> GetFullNCKHGiangVienAsync();
        Task<NCKHGiangVienDTO?> GetNCKHGiangVienAsync(int id);
        Task<bool> AddNCKHGiangVienAsync(NCKHGiangVienDTO nCKHGiangVien);
        Task<bool> UpdateNCKHGiangVienAsync(int id, NCKHGiangVienDTO nCKHGiangVien);
        Task<bool> DeleteNCKHGiangVienAsync(int id);
    }

    public class NCKHGiangVienService : INCKHGiangVienService
    {
        private readonly INCKHGiangVienRepository _nCKHGiangVienRepository;
        private readonly AppDbContext _appDbContext;
        private readonly ILogger<NCKHGiangVienService> _logger;

        public NCKHGiangVienService(
            INCKHGiangVienRepository nCKHGiangVienRepository, 
            AppDbContext appDbContext,
            ILogger<NCKHGiangVienService> logger)
        {
            _nCKHGiangVienRepository = nCKHGiangVienRepository;
            _appDbContext = appDbContext;
            _logger = logger;
        }

        public async Task<List<NCKHGiangVienDTO>> GetFullNCKHGiangVienAsync()
        {
            try
            {
                var deTaiList = await _nCKHGiangVienRepository.GetFullNCKHGiangVienAsync();
                return deTaiList.Select(MapToDTO).ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi lấy danh sách đề tài NCKH Giảng viên");
                return new List<NCKHGiangVienDTO>();
            }
        }

        public async Task<NCKHGiangVienDTO?> GetNCKHGiangVienAsync(int id)
        {
            try
            {
                var deTai = await _nCKHGiangVienRepository.GetByIdAsync(id);
                return deTai != null ? MapToDTO(deTai) : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi lấy đề tài NCKH Giảng viên ID={id}");
                return null;
            }
        }

        public async Task<bool> AddNCKHGiangVienAsync(NCKHGiangVienDTO nCKHGiangVien)
        {
            try
            {
                var entity = await MapToDeTaiEntity(nCKHGiangVien);
                var result = await _nCKHGiangVienRepository.AddNCKHGiangVienAsync(entity);
                return result != null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Lỗi khi thêm đề tài NCKH Giảng viên");
                return false;
            }
        }

        public async Task<bool> UpdateNCKHGiangVienAsync(int id, NCKHGiangVienDTO nCKHGiangVien)
        {
            try
            {
                var existingDeTai = await _nCKHGiangVienRepository.GetByIdAsync(id);
                if (existingDeTai == null) return false;

                await UpdateDeTaiEntityFromDTO(existingDeTai, nCKHGiangVien);
                var result = await _nCKHGiangVienRepository.UpdateNCKHGiangVienAsync(existingDeTai);
                return result != null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi cập nhật đề tài NCKH Giảng viên ID={id}");
                return false;
            }
        }

        public async Task<bool> DeleteNCKHGiangVienAsync(int id)
        {
            try
            {
                var existingDeTai = await _nCKHGiangVienRepository.GetByIdAsync(id);
                if (existingDeTai == null) return false;

                return await _nCKHGiangVienRepository.DeleteNCKHGiangVienAsync(existingDeTai);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Lỗi khi xóa đề tài NCKH Giảng viên ID={id}");
                return false;
            }
        }

        #region Private Helper Methods

        private NCKHGiangVienDTO MapToDTO(DeTaiNghienCuu deTai)
        {
            return new NCKHGiangVienDTO
            {
                ID = deTai.ID,
                MaDeTai = deTai.MaDeTai,
                TenDeTai = deTai.TenDeTai,
                LinhVucNghienCuu = deTai.ID_LinhVucs?.Select(lv => lv.TenLinhVuc).ToList() ?? new List<string>(),
                ChuNhiemDeTai = deTai.ChuNhiemDeTaiNavigation?.HoTen,
                Nganh = deTai.ChuNhiemDeTaiNavigation?.MaBoMonNavigation?.TenBoMon,
                Khoa = deTai.ChuNhiemDeTaiNavigation?.MaBoMonNavigation?.MaKhoaNavigation?.TenKhoa,
                MaChuNhiem = deTai.ChuNhiemDeTai,
                HocVi = deTai.ChuNhiemDeTaiNavigation?.HocVi,
                HocHam = deTai.ChuNhiemDeTaiNavigation?.HocHam,
                NgayBatDau = deTai.NgayBatDau,
                NgayKetThuc = deTai.NgayKetThuc,
                KinhPhi = deTai.KinhPhi,
                TrangThai = deTai.TrangThai,
                NguonKinhPhi = deTai.NguonKinhPhi,
                MucTieu = deTai.MucTieu,
                KetQuaDuKien = deTai.KetQuaDuKien,
                FileHoanThanh = deTai.FileHoanThanh,
                thanhvienthamgia = deTai.ThanhVienDeTais?.Select(tv => new ThanhVien
                {
                    TenThanhVien = tv.MaGVNavigation?.HoTen,
                    MaThanhVien = tv.MaGV,
                    HocVi = tv.MaGVNavigation?.HocVi,
                    HocHam = tv.MaGVNavigation?.HocHam,
                    Nganh = tv.MaGVNavigation?.MaBoMonNavigation?.TenBoMon,
                    Khoa = tv.MaGVNavigation?.MaBoMonNavigation?.MaKhoaNavigation?.TenKhoa
                }).ToList() ?? new List<ThanhVien>()
            };
        }

        private async Task<DeTaiNghienCuu> MapToDeTaiEntity(NCKHGiangVienDTO dto)
        {
            var entity = new DeTaiNghienCuu
            {
                MaDeTai = dto.MaDeTai,
                TenDeTai = dto.TenDeTai,
                ChuNhiemDeTai = dto.MaChuNhiem,
                NgayBatDau = dto.NgayBatDau,
                NgayKetThuc = dto.NgayKetThuc,
                KinhPhi = dto.KinhPhi,
                TrangThai = dto.TrangThai,
                NguonKinhPhi = dto.NguonKinhPhi,
                MucTieu = dto.MucTieu,
                KetQuaDuKien = dto.KetQuaDuKien,
                FileHoanThanh = dto.FileHoanThanh
            };

            // Thêm lĩnh vực nghiên cứu
            if (dto.LinhVucNghienCuu != null && dto.LinhVucNghienCuu.Any())
            {
                var linhVucEntities = await _appDbContext.LinhVucNghienCuus
                    .Where(lv => dto.LinhVucNghienCuu.Contains(lv.TenLinhVuc))
                    .ToListAsync();

                entity.ID_LinhVucs = linhVucEntities;
            }

            // Thêm thành viên tham gia
            if (dto.thanhvienthamgia != null && dto.thanhvienthamgia.Any())
            {
                entity.ThanhVienDeTais = dto.thanhvienthamgia
                    .Where(tv => !string.IsNullOrEmpty(tv?.MaThanhVien))
                    .Select(tv => new ThanhVienDeTai
                    {
                        MaGV = tv!.MaThanhVien
                    })
                    .ToList();
            }

            return entity;
        }

        private async Task UpdateDeTaiEntityFromDTO(DeTaiNghienCuu entity, NCKHGiangVienDTO dto)
        {
            // Cập nhật thông tin cơ bản
            entity.MaDeTai = dto.MaDeTai;
            entity.TenDeTai = dto.TenDeTai;
            entity.ChuNhiemDeTai = dto.MaChuNhiem;
            entity.NgayBatDau = dto.NgayBatDau;
            entity.NgayKetThuc = dto.NgayKetThuc;
            entity.KinhPhi = dto.KinhPhi;
            entity.TrangThai = dto.TrangThai;
            entity.NguonKinhPhi = dto.NguonKinhPhi;
            entity.MucTieu = dto.MucTieu;
            entity.KetQuaDuKien = dto.KetQuaDuKien;
            entity.FileHoanThanh = dto.FileHoanThanh;

            // Cập nhật lĩnh vực nghiên cứu
            entity.ID_LinhVucs.Clear();
            if (dto.LinhVucNghienCuu != null && dto.LinhVucNghienCuu.Any())
            {
                var linhVucEntities = await _appDbContext.LinhVucNghienCuus
                    .Where(lv => dto.LinhVucNghienCuu.Contains(lv.TenLinhVuc))
                    .ToListAsync();

                foreach (var lv in linhVucEntities)
                {
                    entity.ID_LinhVucs.Add(lv);
                }
            }

            // Cập nhật thành viên tham gia
            _appDbContext.ThanhVienDeTais.RemoveRange(entity.ThanhVienDeTais);
            entity.ThanhVienDeTais.Clear();

            if (dto.thanhvienthamgia != null && dto.thanhvienthamgia.Any())
            {
                var thanhVienEntities = dto.thanhvienthamgia
                    .Where(tv => !string.IsNullOrEmpty(tv?.MaThanhVien))
                    .Select(tv => new ThanhVienDeTai
                    {
                        MaGV = tv!.MaThanhVien,
                        MaDeTai = entity.MaDeTai
                    })
                    .ToList();

                entity.ThanhVienDeTais = thanhVienEntities;
            }
        }

        #endregion
    }
}
