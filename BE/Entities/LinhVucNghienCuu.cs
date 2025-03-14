using System;
using System.Collections.Generic;

namespace TLUScience.Entities;

public partial class LinhVucNghienCuu
{
    public int ID { get; set; }

    public string TenLinhVuc { get; set; } = null!;

    public string? MoTa { get; set; }

    public virtual ICollection<DeTaiNghienCuu> MaDeTais { get; set; } = new List<DeTaiNghienCuu>();

    public virtual ICollection<GiangVien> MaGVs { get; set; } = new List<GiangVien>();
}
