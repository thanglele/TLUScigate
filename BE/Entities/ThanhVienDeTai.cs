using System;
using System.Collections.Generic;

namespace TLUScience.Entities;

public partial class ThanhVienDeTai
{
    public string MaDeTai { get; set; } = null!;

    public string MaGV { get; set; } = null!;

    public string? VaiTro { get; set; }

    public DateOnly? ThoiGianThamGia { get; set; }

    public virtual DeTaiNghienCuu MaDeTaiNavigation { get; set; } = null!;

    public virtual GiangVien MaGVNavigation { get; set; } = null!;
}
