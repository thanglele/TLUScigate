namespace TLUScience.DTOs
{
    public class TapChiAnPhamCRUD
    {
        public string MaAnPham { get; set; } = null!;

        public string TenAnPham { get; set; } = null!;

        public string? LoaiAnPham { get; set; }

        public int? NamXuatBan { get; set; }

        public string? NhaXuatBan { get; set; }

        public string? TrangThai { get; set; }

        public string? QuocGia { get; set; }

        public string? NgonNgu { get; set; }

        public string? ISSN_ISBN { get; set; }

        //public virtual GiangVienDTO? MaGiangVienNavigation { get; set; }
    }

    public class TapChiAnPhamDTO : TapChiAnPhamCRUD
    {
        public int ID { get; set; }

        public string? MaGiangVien { get; set; }

    }
}