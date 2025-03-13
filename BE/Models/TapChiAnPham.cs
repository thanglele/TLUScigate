namespace TLUScience.Models
{
    public class TapChiAnPham
    {
        public int ID { get; set; }
        public string MaAnPham { get; set; }
        public string TenAnPham { get; set; }
        public int? NamXuatBan { get; set; }
        public string? NhaXuanBan { get; set; }
        public string? TrangThai {  get; set; }
        public string? QuocGia {  get; set; }
        public string? NgonNgu {  get; set; }
        public string? ISSN_ISBN { get; set; }
        public string? MaGiangVien { get; set; }

        public GiangVien GiangVien { get; set; }
    }
}
