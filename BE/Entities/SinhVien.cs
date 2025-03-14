using System;
using System.Collections.Generic;

namespace TLUScience.Entities;

public partial class SinhVien
{
    public int ID { get; set; }

    public string MaSV { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public string? Email { get; set; }

    public string MaLop { get; set; } = null!;

    public DateOnly? NgaySinh { get; set; }

    public string? SoDienThoai { get; set; }

    public string? DiaChi { get; set; }

    public string? TrangThai { get; set; }

    public virtual Lop MaLopNavigation { get; set; } = null!;

    public virtual ICollection<SinhVienNCKH> SinhVienNCKHs { get; set; } = new List<SinhVienNCKH>();

    public virtual ICollection<TacGiaCongBo> TacGiaCongBos { get; set; } = new List<TacGiaCongBo>();
}
