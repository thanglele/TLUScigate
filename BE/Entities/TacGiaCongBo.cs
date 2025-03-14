using System;
using System.Collections.Generic;

namespace TLUScience.Entities;

public partial class TacGiaCongBo
{
    public int ID { get; set; }

    public string MaCongBo { get; set; } = null!;

    public string? MaGV { get; set; }

    public string? MaSV { get; set; }

    public string? GhiChu { get; set; }

    public virtual CongBoKhoaHoc MaCongBoNavigation { get; set; } = null!;

    public virtual GiangVien? MaGVNavigation { get; set; }

    public virtual SinhVien? MaSVNavigation { get; set; }
}
