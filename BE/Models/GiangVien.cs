namespace TLUScience.Models
{
    public class GiangVien
    {
        public int ID { get; set; }
        public string MaGV { get; set; }
        public string HoTen { get; set; }
        public int? TaiKhoanID { get; set; }
        public string? SoDienThoai {  get; set; }
        public string? MaBoMon { get; set; }
        public string? HocHam {  get; set; }
        public string? HocVi {  get; set; }
        public string? GioiTinh { get; set; }
        public string? ChucVu { get; set; }
        public string? TrangThai { get; set; }
        public DateOnly? NgaySinh { get; set; }
        public string? DiaChi { get; set; }
        public int? NamBatDauLamViec { get; set; }
        public string? GhiChu { get; set; }

        public TaiKhoan TaiKhoan { get; set; }

        public ICollection<TapChiAnPham> tapChiAnPhams { get; set; }
        //public ICollection<GiangVien_LinhVuc> giangVien_LinhVucs { get; set; }
    }
}
