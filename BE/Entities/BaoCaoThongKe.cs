using System;
using System.Collections.Generic;

namespace TLUScience.Entities;

public partial class BaoCaoThongKe
{
    public int ID { get; set; }

    public string MaBaoCao { get; set; } = null!;

    public string TenBaoCao { get; set; } = null!;

    public string? LoaiBaoCao { get; set; }

    public DateOnly? ThoiGianBatDau { get; set; }

    public DateOnly? ThoiGianKetThuc { get; set; }

    public string? NoiDung { get; set; }

    public int? NguoiLap { get; set; }

    public DateOnly? NgayLap { get; set; }

    public string? DuongDanFile { get; set; }

    public string? TrangThaiDuyet { get; set; }

    public virtual TaiKhoan? NguoiLapNavigation { get; set; }
}
