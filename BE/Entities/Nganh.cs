using System;
using System.Collections.Generic;

namespace TLUScience.Entities;

public partial class Nganh
{
    public int ID { get; set; }

    public string MaNganh { get; set; } = null!;

    public string TenNganh { get; set; } = null!;

    public string MaKhoa { get; set; } = null!;

    public string? MoTa { get; set; }

    public string? LoaiNganh { get; set; }

    public int? NamBatDau { get; set; }

    public virtual ICollection<Lop> Lops { get; set; } = new List<Lop>();

    public virtual Khoa MaKhoaNavigation { get; set; } = null!;
}
