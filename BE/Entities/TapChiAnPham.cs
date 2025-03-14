using System;
using System.Collections.Generic;

namespace TLUScience.Entities;

public partial class TapChiAnPham
{
    public int ID { get; set; }

    public string MaAnPham { get; set; } = null!;

    public string TenAnPham { get; set; } = null!;

    public string? LoaiAnPham { get; set; }

    public int? NamXuatBan { get; set; }

    public string? NhaXuatBan { get; set; }

    public string? TrangThai { get; set; }

    public string? QuocGia { get; set; }

    public string? NgonNgu { get; set; }

    public string? ISSN_ISBN { get; set; }

    public string? MaGiangVien { get; set; }

    public virtual GiangVien? MaGiangVienNavigation { get; set; }
}
