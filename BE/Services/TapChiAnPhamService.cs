using TLUScience.DTOs;
using TLUScience.Entities;
using TLUScience.Interface;

public interface ITapChiAnPhamService
{
    public Task<List<TapChiAnPhamDTO>> GetFullTapChiAnPhamAsync();
    public Task<TapChiAnPhamDTO> GetTapChiAnPhamAsync(int id);  
    public Task<bool> AddTapChiAnPhamAsync(TapChiAnPhamCRUD tapChiAnPham, string maGiangVien);
    public Task<bool> UpdateTapChiAnPhamAsync(int id, TapChiAnPhamCRUD tapChiAnPham, string maGiangVien);
    public Task<bool> DeleteTapChiAnPhamAsync(int id);
}

public class TapChiAnPhamService : ITapChiAnPhamService
{
    private readonly ITapChiAnPhamRepository _tapChiAnPhamRepository;
    public TapChiAnPhamService(ITapChiAnPhamRepository tapChiAnPhamRepository)
    {
        _tapChiAnPhamRepository = tapChiAnPhamRepository;
    }

    public async Task<List<TapChiAnPhamDTO>> GetFullTapChiAnPhamAsync()
    {
        var tapChiAnPhams = await _tapChiAnPhamRepository.GetFullTapChiAnPhamAsync();
        return tapChiAnPhams.Select(tapChiAnPham => new TapChiAnPhamDTO
        {
            ID = tapChiAnPham.ID,
            MaAnPham = tapChiAnPham.MaAnPham,
            TenAnPham = tapChiAnPham.TenAnPham,
            LoaiAnPham = tapChiAnPham.LoaiAnPham,
            NamXuatBan = tapChiAnPham.NamXuatBan,
            NhaXuatBan = tapChiAnPham.NhaXuatBan,
            TrangThai = tapChiAnPham.TrangThai,
            QuocGia = tapChiAnPham.QuocGia,
            NgonNgu = tapChiAnPham.NgonNgu,
            ISSN_ISBN = tapChiAnPham.ISSN_ISBN,
            MaGiangVien = tapChiAnPham.MaGiangVien,
            //MaGiangVienNavigation = tapChiAnPham.MaGiangVienNavigation
        }).ToList();
    }

    public async Task<TapChiAnPhamDTO> GetTapChiAnPhamAsync(int id)
    {
        var tapChiAnPham = await _tapChiAnPhamRepository.GetTapChiAnPhamAsync(id);
        return new TapChiAnPhamDTO
        {
            ID = tapChiAnPham.ID,
            MaAnPham = tapChiAnPham.MaAnPham,
            TenAnPham = tapChiAnPham.TenAnPham,
            LoaiAnPham = tapChiAnPham.LoaiAnPham,
            NamXuatBan = tapChiAnPham.NamXuatBan,
            NhaXuatBan = tapChiAnPham.NhaXuatBan,
            TrangThai = tapChiAnPham.TrangThai,
            QuocGia = tapChiAnPham.QuocGia,
            NgonNgu = tapChiAnPham.NgonNgu,
            ISSN_ISBN = tapChiAnPham.ISSN_ISBN,
            MaGiangVien = tapChiAnPham.MaGiangVien,
            //MaGiangVienNavigation = tapChiAnPham.MaGiangVienNavigation
        };
    }

    public async Task<bool> AddTapChiAnPhamAsync(TapChiAnPhamCRUD tapChiAnPham, string maGiangVien)
    {
        var tapChiAnPhamEntity = new TapChiAnPham
        {
            MaAnPham = tapChiAnPham.MaAnPham,
            TenAnPham = tapChiAnPham.TenAnPham,
            LoaiAnPham = tapChiAnPham.LoaiAnPham,
            NamXuatBan = tapChiAnPham.NamXuatBan,
            NhaXuatBan = tapChiAnPham.NhaXuatBan,
            TrangThai = tapChiAnPham.TrangThai,
            QuocGia = tapChiAnPham.QuocGia,
            NgonNgu = tapChiAnPham.NgonNgu,
            ISSN_ISBN = tapChiAnPham.ISSN_ISBN,
            MaGiangVien = maGiangVien,
            //MaGiangVienNavigation = giangVien
        };

        await _tapChiAnPhamRepository.AddTapChiAnPhamAsync(tapChiAnPhamEntity);
        return true;
    }

    public async Task<bool> UpdateTapChiAnPhamAsync(int id, TapChiAnPhamCRUD tapChiAnPham, string maGiangVien)
    {
        var tapChiAnPhamEntity = await _tapChiAnPhamRepository.GetTapChiAnPhamAsync(id);
        if (tapChiAnPhamEntity == null)
        {
            throw new InvalidOperationException("Không tìm thấy tạp chí ấn phẩm này!");
        }

        tapChiAnPhamEntity.MaAnPham = tapChiAnPham.MaAnPham;
        tapChiAnPhamEntity.TenAnPham = tapChiAnPham.TenAnPham;
        tapChiAnPhamEntity.LoaiAnPham = tapChiAnPham.LoaiAnPham;
        tapChiAnPhamEntity.NamXuatBan = tapChiAnPham.NamXuatBan;
        tapChiAnPhamEntity.NhaXuatBan = tapChiAnPham.NhaXuatBan;
        tapChiAnPhamEntity.TrangThai = tapChiAnPham.TrangThai;
        tapChiAnPhamEntity.QuocGia = tapChiAnPham.QuocGia;
        tapChiAnPhamEntity.NgonNgu = tapChiAnPham.NgonNgu;
        tapChiAnPhamEntity.ISSN_ISBN = tapChiAnPham.ISSN_ISBN;
        tapChiAnPhamEntity.MaGiangVien = maGiangVien;

        await _tapChiAnPhamRepository.UpdateTapChiAnPhamAsync(tapChiAnPhamEntity);
        return true;
    }

    public async Task<bool> DeleteTapChiAnPhamAsync(int id)
    {
        var tapChiAnPhamEntity = await _tapChiAnPhamRepository.GetTapChiAnPhamAsync(id);
        if (tapChiAnPhamEntity == null)
        {
            throw new InvalidOperationException("Không tìm thấy tạp chí ấn phẩm này!");
        }

        await _tapChiAnPhamRepository.DeleteTapChiAnPhamAsync(tapChiAnPhamEntity);
        return true;
    }
}