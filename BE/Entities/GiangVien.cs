using System;
using System.Collections.Generic;

namespace TLUScience.Entities;

public partial class GiangVien
{
    public int ID { get; set; }

    public string MaGV { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public int? TaiKhoanID { get; set; }

    public string? SoDienThoai { get; set; }

    public string? MaBoMon { get; set; }

    public string? HocHam { get; set; }

    public string? HocVi { get; set; }

    public string? GioiTinh { get; set; }

    public string? ChucVu { get; set; }

    public string? TrangThai { get; set; }

    public DateOnly? NgaySinh { get; set; }

    public string? DiaChi { get; set; }

    public int? NamBatDauLamViec { get; set; }

    public string? GhiChu { get; set; }

    public virtual ICollection<BanQuanLy> BanQuanLies { get; set; } = new List<BanQuanLy>();

    public virtual ICollection<DeTaiNghienCuu> DeTaiNghienCuus { get; set; } = new List<DeTaiNghienCuu>();

    public virtual ICollection<Lop> Lops { get; set; } = new List<Lop>();

    public virtual BoMon? MaBoMonNavigation { get; set; }

    public virtual ICollection<NghienCuuKhoaHocSinhVien> NghienCuuKhoaHocSinhViens { get; set; } = new List<NghienCuuKhoaHocSinhVien>();

    public virtual ICollection<TacGiaCongBo> TacGiaCongBos { get; set; } = new List<TacGiaCongBo>();

    public virtual TaiKhoan? TaiKhoan { get; set; }

    public virtual ICollection<TapChiAnPham> TapChiAnPhams { get; set; } = new List<TapChiAnPham>();

    public virtual ICollection<ThanhVienDeTai> ThanhVienDeTais { get; set; } = new List<ThanhVienDeTai>();

    public virtual ICollection<LinhVucNghienCuu> ID_LinhVucs { get; set; } = new List<LinhVucNghienCuu>();
}
