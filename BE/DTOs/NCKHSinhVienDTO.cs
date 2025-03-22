namespace TLUScience.DTOs;

public class Status
{
    public string TrangThai { get; set; } = null!;
}
public class NCKHSinhVienCRUD: Status
{
    public string MaNCKH { get; set; } = null!;
    public string TenHoatDong { get; set; } = null!;
    public string TenGiangVien { get; set; } = null!;
    public DateOnly? NgayBatDau { get; set; }
    public DateOnly? NgayKetThuc { get; set; }
    public string KetQua { get; set; } = null!;
    public decimal? KinhPhiHd { get; set; }
    public string DiaDiem { get; set; } = null!;
    public string FileHoanThanh { get; set; } = null!;
}

public class CNKHSinhVienGet: NCKHSinhVienCRUD
{
    public string TruongNhom { get; set; } = null!;
}

public class NCKHSinhVienDTO: CNKHSinhVienGet
{
    public int ID { get; set; }  
           
}