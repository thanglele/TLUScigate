using System;
using System.Collections.Generic;

namespace TLUScience.Entities;

public partial class BoMon
{
    public int ID { get; set; }

    public string MaBoMon { get; set; } = null!;

    public string TenBoMon { get; set; } = null!;

    public string MaKhoa { get; set; } = null!;

    public string? SoDienThoai { get; set; }

    public string? Email { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<GiangVien> GiangViens { get; set; } = new List<GiangVien>();

    public virtual Khoa MaKhoaNavigation { get; set; } = null!;
}
