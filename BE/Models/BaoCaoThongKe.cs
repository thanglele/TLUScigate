namespace TLUScience.Models
{
    public class BaoCaoThongKe
    {
        public int ID { get; set; }
        public string MaBaoCao { get; set; }
        public string TenBaoCao { get; set; }
        public DateOnly? ThoiGianBatDau { get; set; }
        public DateOnly? ThoiGianKetThuc { get; set; }
        public string? NoiDung { get; set; }
        public int? NguoiLap { get; set; }
        public DateOnly? NgayLap { get; set; }
        public string? DuongDanFile { get; set; }
    }
}
