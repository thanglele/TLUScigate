using TLUScience.DTOs;
using TLUScience.Entities;
using TLUScience.Interface;

public interface IGiangVienService
{
    public Task<List<GiangVienDTO>> GetFullGiangVienAsync();
    public Task<GiangVienDTO> GetGiangVienAsync(int id);
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
        return giangViens.Select(MapToDTO).ToList();
    }

    public async Task<GiangVienDTO> GetGiangVienAsync(int id)
    {
        var giangvien = await _giangVienRepository.GetGiangVienAsync(id);
        return giangvien != null ? MapToDTO(giangvien) : null;
    }

    public async Task<bool> AddGiangVienAsync(GiangVienDTO giangVien)
    {
        try
        {
            var entity = MapToEntity(giangVien);
            var result = await _giangVienRepository.AddGiangVienAsync(entity);
            return result != null;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> UpdateGiangVienAsync(int id, GiangVienDTO giangVien)
    {
        try
        {
            var existingEntity = await _giangVienRepository.GetGiangVienAsync(id);
            if (existingEntity == null) return false;

            UpdateEntityFromDTO(existingEntity, giangVien);
            var result = await _giangVienRepository.UpdateGiangVienAsync(existingEntity);
            return result != null;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> DeleteGiangVienAsync(int id)
    {
        try
        {
            var entity = await _giangVienRepository.GetGiangVienAsync(id);
            if (entity == null) return false;

            return await _giangVienRepository.DeleteGiangVienAsync(entity);
        }
        catch
        {
            return false;
        }
    }

    private GiangVienDTO MapToDTO(GiangVien gv) => new GiangVienDTO
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
    };

    private GiangVien MapToEntity(GiangVienDTO dto) => new GiangVien
    {
        MaGV = dto.MaGV,
        HoTen = dto.HoTen,
        HocHam = dto.HocHam,
        HocVi = dto.HocVi,
        ChucVu = dto.ChucVu,
        TrangThai = dto.TrangThai,
        GioiTinh = dto.GioiTinh,
        DiaChi = dto.DiaChi,
        SoDienThoai = dto.SoDienThoai,
        GhiChu = dto.GhiChu
    };

    private void UpdateEntityFromDTO(GiangVien entity, GiangVienDTO dto)
    {
        entity.MaGV = dto.MaGV;
        entity.HoTen = dto.HoTen;
        entity.HocHam = dto.HocHam;
        entity.HocVi = dto.HocVi;
        entity.ChucVu = dto.ChucVu;
        entity.TrangThai = dto.TrangThai;
        entity.GioiTinh = dto.GioiTinh;
        entity.DiaChi = dto.DiaChi;
        entity.SoDienThoai = dto.SoDienThoai;
        entity.GhiChu = dto.GhiChu;
    }
}