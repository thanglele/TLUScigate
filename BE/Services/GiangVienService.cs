using TLUScience.DTOs;
using TLUScience.Interface;

public interface IGiangVienService
{
    public Task<List<GiangVienDTO>> GetFullGiangVienAsync();
    // public Task<GiangVienCRUD> GetGiangVienAsync(int id);
    // public Task<GiangVienDTO> AddGiangVienAsync(GiangVienDTO giangVien);
    // public Task<GiangVienDTO> UpdateGiangVienAsync(GiangVienDTO giangVien);
    // public Task<bool> DeleteGiangVienAsync(int id);
}

public class GiangVienService : IGiangVienService
{
    private readonly IGiangVienRepository _giangVienRepository;

    public GiangVienService(IGiangVienRepository giangVienRepository)
    {
        _giangVienRepository = giangVienRepository;
    }

    public async Task<List<GiangVienDTO>> GetFullGiangVienAsync()
    {
        var giangViens = await _giangVienRepository.GetFullGiangVienAsync();
        return giangViens.Select(gv => new GiangVienDTO
        {
            ID = gv.ID,
            MaGV = gv.MaGV,
            HoTen = gv.HoTen,
            Email = gv.TaiKhoan?.Email ?? "",
            HocHam = gv.HocHam ?? "",
            HocVi = gv.HocVi ?? "",
            ChucVu = gv.ChucVu ?? "",
            TrangThai = gv.TrangThai ?? "",
            ChuyenNganh = gv.MaBoMonNavigation?.TenBoMon ?? "",
            GioiTinh = gv.GioiTinh ?? "",
            DiaChi = gv.DiaChi ?? "",
            SoDienThoai = gv.SoDienThoai ?? "",
            NgaySinh = gv.NgaySinh,
            GhiChu = gv.GhiChu ?? ""
        }).ToList();

    }
}