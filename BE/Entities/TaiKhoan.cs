using System;
using System.Collections.Generic;

namespace TLUScience.Entities;

public partial class TaiKhoan
{
    public int ID { get; set; }

    public string Email { get; set; } = null!;

    public string? MatKhau { get; set; }

    public string VaiTro { get; set; } = null!;

    public virtual BanQuanLy? BanQuanLy { get; set; }

    public virtual ICollection<BaoCaoThongKe> BaoCaoThongKes { get; set; } = new List<BaoCaoThongKe>();

    public virtual GiangVien? GiangVien { get; set; }

    public virtual ICollection<OTP> OTPs { get; set; } = new List<OTP>();
}
