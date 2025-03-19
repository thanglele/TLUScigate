using TLUScience.DTOs;
using TLUScience.Entities;
using TLUScience.Interface;

public interface IGiangVienService
{
    public Task<List<GiangVienDTO>> GetFullGiangVienAsync();
    public Task<GiangVienCRUD> GetGiangVienAsync(int id);
    public Task<bool> AddGiangVienAsync(GiangVienDTO giangVien);
    public Task<bool> UpdateGiangVienAsync(int id, GiangVienDTO giangVien);
    public Task<bool> DeleteGiangVienAsync(int id);
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
    public async Task<GiangVienCRUD> GetGiangVienAsync(int id)
    {
        var giangvien = await _giangVienRepository.GetGiangVienAsync(id);
        string nganh = "";
        foreach (var item in giangvien.Lops) 
        {
            nganh = item.MaNganhNavigation.TenNganh;
            break;
        }    
        return new GiangVienCRUD()
        {
            MaGV = giangvien.MaGV,
            HoTen = giangvien.HoTen,
            Email = giangvien.TaiKhoan.Email,
            HocHam = giangvien.HocHam,
            HocVi = giangvien.HocVi,
            ChucVu = giangvien.ChucVu,
            TrangThai = giangvien.TrangThai,
            ChuyenNganh = nganh,
            GioiTinh = giangvien.GioiTinh,
            DiaChi = giangvien.DiaChi,
            SoDienThoai = giangvien.SoDienThoai,
            GhiChu = giangvien.GhiChu
        };
    }
    public async Task<bool> AddGiangVienAsync(GiangVienDTO giangVien)
    {
        var giangvienEntity = new GiangVien
        {
            MaGV = giangVien.MaGV,
            HoTen = giangVien.HoTen,
            HocHam = giangVien.HocHam,
            HocVi = giangVien.HocVi,
            ChucVu = giangVien.ChucVu,
            TrangThai = giangVien.TrangThai,
            GioiTinh = giangVien.GioiTinh,
            DiaChi = giangVien.DiaChi,
            SoDienThoai = giangVien.SoDienThoai,
            GhiChu = giangVien.GhiChu
        };
        await _giangVienRepository.AddGiangVienAsync(giangvienEntity);
        return true;
    }
    public async Task<bool> UpdateGiangVienAsync(int id, GiangVienDTO giangVien)
    {
        var giangvienEntity = await _giangVienRepository.GetGiangVienAsync(id);
        giangvienEntity.MaGV = giangVien.MaGV;
        giangvienEntity.HoTen = giangVien.HoTen;
        giangvienEntity.HocHam = giangVien.HocHam;
        giangvienEntity.HocVi = giangVien.HocVi;
        giangvienEntity.ChucVu = giangVien.ChucVu;
        giangvienEntity.TrangThai = giangVien.TrangThai;
        giangvienEntity.GioiTinh = giangVien.GioiTinh;
        giangvienEntity.DiaChi = giangVien.DiaChi;
        giangvienEntity.SoDienThoai = giangVien.SoDienThoai;
        giangvienEntity.GhiChu = giangVien.GhiChu;
        await _giangVienRepository.UpdateGiangVienAsync(giangvienEntity);
        return true;
    }

    public async Task<bool> DeleteGiangVienAsync(int id)
    {
        var giangvien = await _giangVienRepository.GetGiangVienAsync(id);
        await _giangVienRepository.DeleteGiangVienAsync(giangvien);
        return true;
    }
}