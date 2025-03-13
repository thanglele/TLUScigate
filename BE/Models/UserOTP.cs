namespace TLUScience.Models
{
    public class UserOTP
    {
        public int Id { get; set; }
        public int TaiKhoanID { get; set; }
        public string MaOTP { get; set; }
        public DateTime ThoiGianTao { get; set; } = DateTime.Now;
        public DateTime ThoiGianHetHan { get; set; } = DateTime.Now.AddMinutes(5);
        public string? TrangThai { get; set; }
        public TaiKhoan TaiKhoan { get; set; }
    }
}
