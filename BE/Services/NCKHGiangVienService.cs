using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkiaSharp;
using TLUScience.DTOs;
using TLUScience.Entities;
using TLUScience.Interface;
using TLUScience.Repository;

namespace TLUScience.Services
{
    public interface INCKHGiangVienService
    {
        public Task<List<NCKHGiangVienDTO>> GetFullNCKHGiangVienAsync();
        public Task<NCKHGiangVienDTO> GetNCKHGiangVienAsync(int id);
        public Task<bool> AddNCKHGiangVienAsync(NCKHGiangVienDTO nCKHSinhVien);
        public Task<bool> UpdateNCKHGiangVienAsync(int id, NCKHGiangVienDTO nCKHSinhVien);
        public Task<bool> DeleteNCKHGiangVienAsync(int id);
    }
    public class NCKHGiangVienService : INCKHGiangVienService
    {
        private readonly IGiangVienRepository _GiangVienRepository;
        private readonly INCKHGiangVienRepository _NCKHGiangVienRepository;
        private readonly AppDbContext _appDbContext;

        public NCKHGiangVienService(IGiangVienRepository GiangVienRepository, INCKHGiangVienRepository nCKHGiangVienRepository, AppDbContext appDbContext)
        {
            _GiangVienRepository = GiangVienRepository;
            _NCKHGiangVienRepository = nCKHGiangVienRepository;
            _appDbContext = appDbContext;
        }


        public async Task<List<NCKHGiangVienDTO>> GetFullNCKHGiangVienAsync()
        {
            var nckhGiangViens = await _NCKHGiangVienRepository.GetFullNCKHGiangVienAsync();
            var giangViens = await _GiangVienRepository.GetFullGiangVienAsync();
            var linhvucs = await _appDbContext.LinhVucNghienCuus.ToListAsync();

            List<NCKHGiangVienDTO> nCKHGiangVienDTOs = new List<NCKHGiangVienDTO>();
            for (int i = 0; i < nckhGiangViens.Count(); i++)
            {
                var temp = new NCKHGiangVienDTO()
                {
                    MaDeTai = nckhGiangViens[i].MaDeTai,
                    TenDeTai = nckhGiangViens[i].TenDeTai,
                    LinhVucNghienCuu = nckhGiangViens[i].ID_LinhVucs.Select(linhvuc => linhvuc.TenLinhVuc).ToList(),
                    ChuNhiemDeTai = nckhGiangViens[i].ChuNhiemDeTai,
                    Nganh = nckhGiangViens[i].ChuNhiemDeTaiNavigation.MaBoMonNavigation.TenBoMon,
                    Khoa = nckhGiangViens[i].ChuNhiemDeTaiNavigation.MaBoMonNavigation.MaKhoaNavigation.TenKhoa,
                    MaChuNhiem = nckhGiangViens[i].ChuNhiemDeTaiNavigation.MaGV,
                    HocVi = nckhGiangViens[i].ChuNhiemDeTaiNavigation.HocVi,
                    HocHam = nckhGiangViens[i].ChuNhiemDeTaiNavigation.HocHam,
                    NgayBatDau = nckhGiangViens[i].NgayBatDau,
                    NgayKetThuc = nckhGiangViens[i].NgayKetThuc,
                    KinhPhi = nckhGiangViens[i].KinhPhi,
                    TrangThai = nckhGiangViens[i].TrangThai,
                    NguonKinhPhi = nckhGiangViens[i].TrangThai,
                    MucTieu = nckhGiangViens[i].MucTieu,
                    KetQuaDuKien = nckhGiangViens[i].KetQuaDuKien,
                    FileHoanThanh = nckhGiangViens[i].FileHoanThanh
                };
                var thanhvienthamgias = (from thanhvien in nckhGiangViens[i].ThanhVienDeTais
                                         join thongtin in giangViens on thanhvien.MaGVNavigation.MaGV equals thongtin.MaGV
                                         select new ThanhVien()
                                         {
                                             TenThanhVien = thongtin.HoTen,
                                             MaThanhVien = thanhvien.MaGV,
                                             HocHam = thongtin.HocHam,
                                             HocVi = thongtin.HocVi,
                                             Nganh = thongtin.MaBoMonNavigation.TenBoMon,
                                             Khoa = thongtin.MaBoMonNavigation.MaKhoaNavigation.TenKhoa
                                         }).ToList(); // Chuyển kết quả thành danh sách

                // Sửa chỗ này: Dùng AddRange thay vì Add
                temp.thanhvienthamgia.AddRange(thanhvienthamgias);

                nCKHGiangVienDTOs.Add(temp);
            }
            return nCKHGiangVienDTOs;
        }

        public async Task<NCKHGiangVienDTO> GetNCKHGiangVienAsync(int id)
        {
            var nckhGiangViens = await _NCKHGiangVienRepository.GetFullNCKHGiangVienAsync();
            var giangViens = await _GiangVienRepository.GetFullGiangVienAsync();
            var linhvucs = await _appDbContext.LinhVucNghienCuus.ToListAsync();

            List<NCKHGiangVienDTO> nCKHGiangVienDTOs = new List<NCKHGiangVienDTO>();
            for (int i = 0; i < nckhGiangViens.Count(); i++)
            {
                var temp = new NCKHGiangVienDTO()
                {
                    MaDeTai = nckhGiangViens[i].MaDeTai,
                    TenDeTai = nckhGiangViens[i].TenDeTai,
                    LinhVucNghienCuu = nckhGiangViens[i].ID_LinhVucs.Select(linhvuc => linhvuc.TenLinhVuc).ToList(),
                    ChuNhiemDeTai = nckhGiangViens[i].ChuNhiemDeTai,
                    Nganh = nckhGiangViens[i].ChuNhiemDeTaiNavigation.MaBoMonNavigation.TenBoMon,
                    Khoa = nckhGiangViens[i].ChuNhiemDeTaiNavigation.MaBoMonNavigation.MaKhoaNavigation.TenKhoa,
                    MaChuNhiem = nckhGiangViens[i].ChuNhiemDeTaiNavigation.MaGV,
                    HocVi = nckhGiangViens[i].ChuNhiemDeTaiNavigation.HocVi,
                    HocHam = nckhGiangViens[i].ChuNhiemDeTaiNavigation.HocHam,
                    NgayBatDau = nckhGiangViens[i].NgayBatDau,
                    NgayKetThuc = nckhGiangViens[i].NgayKetThuc,
                    KinhPhi = nckhGiangViens[i].KinhPhi,
                    TrangThai = nckhGiangViens[i].TrangThai,
                    NguonKinhPhi = nckhGiangViens[i].TrangThai,
                    MucTieu = nckhGiangViens[i].MucTieu,
                    KetQuaDuKien = nckhGiangViens[i].KetQuaDuKien,
                    FileHoanThanh = nckhGiangViens[i].FileHoanThanh
                };
                var thanhvienthamgias = (from thanhvien in nckhGiangViens[i].ThanhVienDeTais
                                         join thongtin in giangViens on thanhvien.MaGVNavigation.MaGV equals thongtin.MaGV
                                         select new ThanhVien()
                                         {
                                             TenThanhVien = thongtin.HoTen,
                                             MaThanhVien = thanhvien.MaGV,
                                             HocHam = thongtin.HocHam,
                                             HocVi = thongtin.HocVi,
                                             Nganh = thongtin.MaBoMonNavigation.TenBoMon,
                                             Khoa = thongtin.MaBoMonNavigation.MaKhoaNavigation.TenKhoa
                                         }).ToList(); // Chuyển kết quả thành danh sách

                // Sửa chỗ này: Dùng AddRange thay vì Add
                temp.thanhvienthamgia.AddRange(thanhvienthamgias);

                nCKHGiangVienDTOs.Add(temp);
            }
            return nCKHGiangVienDTOs[id];
        }

        public async Task<bool> AddNCKHGiangVienAsync(NCKHGiangVienDTO nCKHSinhVien)
        {
            // Tạo đối tượng NCKHGiangVien mới
            var newNCKH = new DeTaiNghienCuu
            {
                MaDeTai = nCKHSinhVien.MaDeTai,
                TenDeTai = nCKHSinhVien.TenDeTai,
                ChuNhiemDeTai = nCKHSinhVien.MaChuNhiem,
                NgayBatDau = nCKHSinhVien.NgayBatDau,
                NgayKetThuc = nCKHSinhVien.NgayKetThuc,
                KinhPhi = nCKHSinhVien.KinhPhi,
                TrangThai = nCKHSinhVien.TrangThai,
                NguonKinhPhi = nCKHSinhVien.NguonKinhPhi,
                MucTieu = nCKHSinhVien.MucTieu,
                KetQuaDuKien = nCKHSinhVien.KetQuaDuKien,
                FileHoanThanh = nCKHSinhVien.FileHoanThanh
            };

            // Thêm lĩnh vực nghiên cứu (nếu có)
            if (nCKHSinhVien.LinhVucNghienCuu != null && nCKHSinhVien.LinhVucNghienCuu.Any())
            {
                var linhVucEntities = await _appDbContext.LinhVucNghienCuus
                    .Where(lv => nCKHSinhVien.LinhVucNghienCuu.Contains(lv.TenLinhVuc))
                    .ToListAsync();

                newNCKH.ID_LinhVucs = linhVucEntities;
            }

            // Thêm danh sách thành viên tham gia (nếu có)
            if (nCKHSinhVien.thanhvienthamgia != null && nCKHSinhVien.thanhvienthamgia.Any())
            {
                newNCKH.ThanhVienDeTais = nCKHSinhVien.thanhvienthamgia.Select(tv => new ThanhVienDeTai
                {
                    MaGV = tv.MaThanhVien
                }).ToList();
            }

            await _NCKHGiangVienRepository.AddNCKHGiangVienAsync(newNCKH);
            return true;
        }

        public async Task<bool> UpdateNCKHGiangVienAsync(int id, NCKHGiangVienDTO nCKHGiangVien)
        {
            var existingNCKH = await _appDbContext.DeTaiNghienCuus
            .Include(n => n.ID_LinhVucs)
            .Include(n => n.ThanhVienDeTais)
            .FirstOrDefaultAsync(n => n.ID == id);

            if (existingNCKH == null)
                return false;

            // Cập nhật thông tin cơ bản
            existingNCKH.MaDeTai = nCKHGiangVien.MaDeTai;
            existingNCKH.TenDeTai = nCKHGiangVien.TenDeTai;
            existingNCKH.ChuNhiemDeTai = nCKHGiangVien.MaChuNhiem;
            existingNCKH.NgayBatDau = nCKHGiangVien.NgayBatDau;
            existingNCKH.NgayKetThuc = nCKHGiangVien.NgayKetThuc;
            existingNCKH.KinhPhi = nCKHGiangVien.KinhPhi;
            existingNCKH.TrangThai = nCKHGiangVien.TrangThai;
            existingNCKH.NguonKinhPhi = nCKHGiangVien.NguonKinhPhi;
            existingNCKH.MucTieu = nCKHGiangVien.MucTieu;
            existingNCKH.KetQuaDuKien = nCKHGiangVien.KetQuaDuKien;
            existingNCKH.FileHoanThanh = nCKHGiangVien.FileHoanThanh;

            // Cập nhật lĩnh vực nghiên cứu
            if (nCKHGiangVien.LinhVucNghienCuu != null && nCKHGiangVien.LinhVucNghienCuu.Any())
            {
                var linhVucEntities = await _appDbContext.LinhVucNghienCuus
                    .Where(lv => nCKHGiangVien.LinhVucNghienCuu.Contains(lv.TenLinhVuc))
                    .ToListAsync();

                // Xóa lĩnh vực cũ
                existingNCKH.ID_LinhVucs.Clear();

                // Thêm lĩnh vực mới từng cái một
                foreach (var linhVuc in linhVucEntities)
                {
                    existingNCKH.ID_LinhVucs.Add(linhVuc);
                }
            }

            // Cập nhật danh sách thành viên tham gia
            if (nCKHGiangVien.thanhvienthamgia != null)
            {
                existingNCKH.ThanhVienDeTais.Clear();
                existingNCKH.ThanhVienDeTais = nCKHGiangVien.thanhvienthamgia.Select(tv => new ThanhVienDeTai
                {
                    MaGV = tv.MaThanhVien
                }).ToList();
            }

            await _NCKHGiangVienRepository.UpdateNCKHGiangVienAsync(existingNCKH);
            return true;
        }

        public async Task<bool> DeleteNCKHGiangVienAsync(int id)
        {
            var existingNCKH = await _NCKHGiangVienRepository.GetByIdAsync(id);
            if (existingNCKH == null) return false;

            return await _NCKHGiangVienRepository.DeleteNCKHGiangVienAsync(existingNCKH);
        }
    }
}
