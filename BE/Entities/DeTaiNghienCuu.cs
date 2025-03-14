using System;
using System.Collections.Generic;

namespace TLUScience.Entities;

public partial class DeTaiNghienCuu
{
    public int ID { get; set; }

    public string MaDeTai { get; set; } = null!;

    public string TenDeTai { get; set; } = null!;

    public string? ChuNhiemDeTai { get; set; }

    public DateOnly? NgayBatDau { get; set; }

    public DateOnly? NgayKetThuc { get; set; }

    public decimal? KinhPhi { get; set; }

    public string? TrangThai { get; set; }

    public string? NguonKinhPhi { get; set; }

    public string? MucTieu { get; set; }

    public string? KetQuaDuKien { get; set; }

    public string? FileHoanThanh { get; set; }

    public virtual GiangVien? ChuNhiemDeTaiNavigation { get; set; }

    public virtual ICollection<ThanhVienDeTai> ThanhVienDeTais { get; set; } = new List<ThanhVienDeTai>();

    public virtual ICollection<TienDo> TienDos { get; set; } = new List<TienDo>();

    public virtual ICollection<LinhVucNghienCuu> ID_LinhVucs { get; set; } = new List<LinhVucNghienCuu>();
}
