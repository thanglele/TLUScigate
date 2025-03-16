namespace TLUScience.DTOs
{
    public class BaoCaoThongKeCRUD
    {
        public string MaBaoCao { get; set; } = null!;

        public string TenBaoCao { get; set; } = null!;

        public string? LoaiBaoCao { get; set; }

        public DateOnly? ThoiGianBatDau { get; set; }

        public DateOnly? ThoiGianKetThuc { get; set; }

        public string? NoiDung { get; set; }

        public string? DuongDanFile { get; set; }

        public string? TrangThai { get; set; }

    }

    public class BaoCaoThongKeDTO:BaoCaoThongKeCRUD
    {
        public int ID { get; set; }
    }
}
