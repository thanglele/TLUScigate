using System;
using System.Collections.Generic;

namespace TLUScience.Entities;

public partial class Khoa
{
    public int ID { get; set; }

    public string MaKhoa { get; set; } = null!;

    public string TenKhoa { get; set; } = null!;

    public string? DiaChi { get; set; }

    public string? SoDienThoaiKhoa { get; set; }

    public string? EmailKhoa { get; set; }

    public DateOnly? NgayThanhLap { get; set; }

    public string? MoTa { get; set; }

    public virtual ICollection<BoMon> BoMons { get; set; } = new List<BoMon>();

    public virtual ICollection<Nganh> Nganhs { get; set; } = new List<Nganh>();
}
