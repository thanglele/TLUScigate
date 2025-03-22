using System;
using System.Collections.Generic;

namespace TLUScience.Entities;

public partial class CongBoKhoaHoc
{
    public int ID { get; set; }

    public string MaCongBo { get; set; } = null!;

    public string TieuDe { get; set; } = null!;

    public string TomTat { get; set; } = null!;

    public string? TuKhoa { get; set; }

    public string? NgonNgu { get; set; }

    public string? LoaiCongBo { get; set; }

    public string? ISSN_ISBN { get; set; }

    public string? ChiMucKhoaHoc { get; set; }

    public decimal? ImpactFactor { get; set; }

    public string? DOI { get; set; }

    public int? NamCongBo { get; set; }

    public int? SoTrang { get; set; }

    public string? FileDinhKem { get; set; }

    public virtual ICollection<TacGiaCongBo> TacGiaCongBos { get; set; } = new List<TacGiaCongBo>();

    public string? TrangThai {  get; set; }
}
