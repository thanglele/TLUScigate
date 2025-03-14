using System;
using System.Collections.Generic;

namespace TLUScience.Entities;

public partial class Lop
{
    public int ID { get; set; }

    public string MaLop { get; set; } = null!;

    public string TenLop { get; set; } = null!;

    public string MaNganh { get; set; } = null!;

    public int NamNhapHoc { get; set; }

    public string? GiaoVienChuNhiem { get; set; }

    public string? TrangThai { get; set; }

    public virtual GiangVien? GiaoVienChuNhiemNavigation { get; set; }

    public virtual Nganh MaNganhNavigation { get; set; } = null!;

    public virtual ICollection<SinhVien> SinhViens { get; set; } = new List<SinhVien>();
}
