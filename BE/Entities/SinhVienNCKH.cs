using System;
using System.Collections.Generic;

namespace TLUScience.Entities;

public partial class SinhVienNCKH
{
    public string MaNCKH { get; set; } = null!;

    public string MaSV { get; set; } = null!;

    public string? VaiTro { get; set; }

    public DateOnly? ThoiGianThamGia { get; set; }

    public string? KetQuaCaNhan { get; set; }

    public virtual NghienCuuKhoaHocSinhVien MaNCKHNavigation { get; set; } = null!;

    public virtual SinhVien MaSVNavigation { get; set; } = null!;
}
