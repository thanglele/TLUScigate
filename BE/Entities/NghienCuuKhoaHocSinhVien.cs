using System;
using System.Collections.Generic;

namespace TLUScience.Entities;

public partial class NghienCuuKhoaHocSinhVien
{
    public int ID { get; set; }

    public string MaNCKH { get; set; } = null!;

    public string TenHoatDong { get; set; } = null!;

    public string? GiangVienHuongDan { get; set; }

    public DateOnly? NgayBatDau { get; set; }

    public DateOnly? NgayKetThuc { get; set; }

    public string? KetQua { get; set; }

    public string? TrangThai { get; set; }

    public decimal? KinhPhiHoatDong { get; set; }

    public string? DiaDiem { get; set; }

    public string? FileHoanThanh { get; set; }

    public virtual GiangVien? GiangVienHuongDanNavigation { get; set; }

    public virtual ICollection<SinhVienNCKH> SinhVienNCKHs { get; set; } = new List<SinhVienNCKH>();

    public virtual ICollection<TienDo> TienDos { get; set; } = new List<TienDo>();
}
