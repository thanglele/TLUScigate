namespace TLUScience.DTOs;

public class CongBoKhoaHocCRUD
{
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
}

public class CongBoKhoaHocDTO : CongBoKhoaHocCRUD
{
    public int ID { get; set; }
}
