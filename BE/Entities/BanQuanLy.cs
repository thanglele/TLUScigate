using System;
using System.Collections.Generic;

namespace TLUScience.Entities;

public partial class BanQuanLy
{
    public int ID { get; set; }

    public string MaBQL { get; set; } = null!;

    public string HoTen { get; set; } = null!;

    public int? TaiKhoanID { get; set; }

    public string? SoDienThoai { get; set; }

    public string? ChucVu { get; set; }

    public string? MaGiangVien { get; set; }

    public string? TrangThai { get; set; }

    public virtual GiangVien? MaGiangVienNavigation { get; set; }

    public virtual TaiKhoan? TaiKhoan { get; set; }

    public virtual ICollection<TienDo> TienDos { get; set; } = new List<TienDo>();
}
