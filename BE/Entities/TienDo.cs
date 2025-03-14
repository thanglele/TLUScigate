using System;
using System.Collections.Generic;

namespace TLUScience.Entities;

public partial class TienDo
{
    public int ID { get; set; }

    public string? MaDeTai { get; set; }

    public string? MaNCKH { get; set; }

    public string? TrangThai { get; set; }

    public string? FileDinhKem { get; set; }

    public string? NguoiDuyet { get; set; }

    public virtual DeTaiNghienCuu? MaDeTaiNavigation { get; set; }

    public virtual NghienCuuKhoaHocSinhVien? MaNCKHNavigation { get; set; }

    public virtual BanQuanLy? NguoiDuyetNavigation { get; set; }
}
