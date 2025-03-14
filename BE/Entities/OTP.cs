using System;
using System.Collections.Generic;

namespace TLUScience.Entities;

public partial class OTP
{
    public int ID { get; set; }

    public int TaiKhoanID { get; set; }

    public string MaOTP { get; set; } = null!;

    public DateTime ThoiGianTao { get; set; }

    public DateTime ThoiGianHetHan { get; set; }

    public string? TrangThai { get; set; }

    public virtual TaiKhoan TaiKhoan { get; set; } = null!;
}
