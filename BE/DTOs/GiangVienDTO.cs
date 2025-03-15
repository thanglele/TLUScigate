namespace TLUScience.DTOs;

public class GiangVienCRUD
{
    public string MaGV { get; set; } = null!;
    public string HoTen { get; set; }
    public string Email { get; set; }
    public string HocHam { get; set; }
    public string HocVi { get; set; }
    public string ChucVu { get; set; }
    public string TrangThai { get; set; }
    public string ChuyenNganh { get; set; } = null!;
    public string GioiTinh { get; set; }
    public string DiaChi { get; set; }
    public string SoDienThoai { get; set; }
    public DateOnly? NgaySinh { get; set; }
    public string GhiChu { get; set; }
}

public class GiangVienDTO: GiangVienCRUD
{
    public int ID { get; set; }
}