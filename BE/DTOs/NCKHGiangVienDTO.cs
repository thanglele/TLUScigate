using System;
using System.Collections.Generic;
using TLUScience.Entities;

namespace TLUScience.DTOs
{
    public class NCKHGiangVienDTO
    {
        public int ID { get; set; }
        public string MaDeTai { get; set; } = null!;
        public string TenDeTai { get; set; } = null!;
        public List<string> LinhVucNghienCuu { get; set; } = new List<string>();
        public string? ChuNhiemDeTai { get; set; }
        public string? Nganh { get; set; }
        public string? Khoa { get; set; }
        public string? MaChuNhiem { get; set; }
        public string? HocVi { get; set; }
        public string? HocHam { get; set; }
        public DateOnly? NgayBatDau { get; set; }
        public DateOnly? NgayKetThuc { get; set; }
        public List<ThanhVien?> thanhvienthamgia { get; set; } = new List<ThanhVien?>();
        public decimal? KinhPhi { get; set; }
        public string? TrangThai { get; set; }
        public string? NguonKinhPhi { get; set; }
        public string? MucTieu { get; set; }
        public string? KetQuaDuKien { get; set; }
        public string? FileHoanThanh { get; set; }
    }

    public class ThanhVien
    {
        public string? TenThanhVien { get; set; }
        public string? MaThanhVien { get; set; }
        public string? HocVi { get; set; }
        public string? HocHam { get; set; }
        public string? Nganh { get; set; }
        public string? Khoa { get; set; }
    }
}
