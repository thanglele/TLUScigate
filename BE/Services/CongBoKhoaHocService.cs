using TLUScience.DTOs;
using TLUScience.Entities;
using TLUScience.Interface;

public interface ICongBoKhoaHocService
{
    public Task<List<CongBoKhoaHocDTO>> GetFullCongBoKhoaHocAsync();
    public Task<CongBoKhoaHocDTO> GetCongBoKhoaHocAsync(int id);  
    public Task<bool> AddCongBoKhoaHocAsync(CongBoKhoaHocCRUD congBoKhoaHoc);
    public Task<bool> UpdateCongBoKhoaHocAsync(int id, CongBoKhoaHocCRUD congBoKhoaHoc);
    public Task<bool> DeleteCongBoKhoaHocAsync(int id);
    public Task<bool> UpdateStatus(int id, CBKHStatus status);
}

public class CongBoKhoaHocService : ICongBoKhoaHocService
{
    private readonly ICongBoKhoaHocRepository _congBoKhoaHocRepository;
    private readonly ITacGiaCongBoRepository _tacGiaCongBo;
    private readonly IGiangVienRepository _giangVienRepository;

    public CongBoKhoaHocService(ICongBoKhoaHocRepository congBoKhoaHocRepository, ITacGiaCongBoRepository tacGiaCongBo, IGiangVienRepository giangVienRepository)
    {
        _giangVienRepository = giangVienRepository;
        _congBoKhoaHocRepository = congBoKhoaHocRepository;
        _tacGiaCongBo = tacGiaCongBo;
    }

    public async Task<List<CongBoKhoaHocDTO>> GetFullCongBoKhoaHocAsync()
    {
        var congBoKhoaHocs = await _congBoKhoaHocRepository.GetFullCongBoKhoaHocAsync();
        var giangViens = await _giangVienRepository.GetFullGiangVienAsync();
        var tacGiaCongBos = await _tacGiaCongBo.GetFullTacGiaCongBoAsync();
        
        var name = (from tacGia in tacGiaCongBos
                    join giangVien in giangViens on tacGia.MaGV equals giangVien.MaGV
                    select new { tacGia.MaCongBo, giangVien.HoTen }).ToList();
        
        return congBoKhoaHocs.Select(congBoKhoaHoc => new CongBoKhoaHocDTO
        {
            ID = congBoKhoaHoc.ID,
            MaCongBo = congBoKhoaHoc.MaCongBo,
            TieuDe = congBoKhoaHoc.TieuDe,
            TacGia = name.FirstOrDefault(x => x.MaCongBo == congBoKhoaHoc.MaCongBo)?.HoTen ?? string.Empty,
            TomTat = congBoKhoaHoc.TomTat,
            TuKhoa = congBoKhoaHoc.TuKhoa,
            NgonNgu = congBoKhoaHoc.NgonNgu,
            LoaiCongBo = congBoKhoaHoc.LoaiCongBo,
            ISSN_ISBN = congBoKhoaHoc.ISSN_ISBN,
            ChiMucKhoaHoc = congBoKhoaHoc.ChiMucKhoaHoc,
            ImpactFactor = congBoKhoaHoc.ImpactFactor,
            DOI = congBoKhoaHoc.DOI,
            NamCongBo = congBoKhoaHoc.NamCongBo,
            SoTrang = congBoKhoaHoc.SoTrang,
            FileDinhKem = congBoKhoaHoc.FileDinhKem,
        }).ToList();
    }
    


    public async Task<CongBoKhoaHocDTO> GetCongBoKhoaHocAsync(int id)
    {
        var congBoKhoaHoc = await _congBoKhoaHocRepository.GetCongBoKhoaHocAsync(id);
        var MaCongBo = congBoKhoaHoc.MaCongBo;

        var tenTacGia = (from tacGia in await _tacGiaCongBo.GetFullTacGiaCongBoAsync()
                         join giangVien in await _giangVienRepository.GetFullGiangVienAsync() on tacGia.MaGV equals giangVien.MaGV
                         where tacGia.MaCongBo == MaCongBo
                         select giangVien.HoTen).ToList();

        return new CongBoKhoaHocDTO
        {
            ID = congBoKhoaHoc.ID,
            MaCongBo = congBoKhoaHoc.MaCongBo,
            TieuDe = congBoKhoaHoc.TieuDe,
            TacGia = tenTacGia.FirstOrDefault() ?? string.Empty,
            TomTat = congBoKhoaHoc.TomTat,
            TuKhoa = congBoKhoaHoc.TuKhoa,
            NgonNgu = congBoKhoaHoc.NgonNgu,
            LoaiCongBo = congBoKhoaHoc.LoaiCongBo,
            ISSN_ISBN = congBoKhoaHoc.ISSN_ISBN,
            ChiMucKhoaHoc = congBoKhoaHoc.ChiMucKhoaHoc,
            ImpactFactor = congBoKhoaHoc.ImpactFactor,
            DOI = congBoKhoaHoc.DOI,
            NamCongBo = congBoKhoaHoc.NamCongBo,
            SoTrang = congBoKhoaHoc.SoTrang,
            FileDinhKem = congBoKhoaHoc.FileDinhKem
        };
    }

    public async Task<bool> AddCongBoKhoaHocAsync(CongBoKhoaHocCRUD congBoKhoaHoc)
    {
        var congBoKhoaHocEntity = new CongBoKhoaHoc
        {
            MaCongBo = congBoKhoaHoc.MaCongBo,
            TieuDe = congBoKhoaHoc.TieuDe,
            TomTat = congBoKhoaHoc.TomTat,
            TuKhoa = congBoKhoaHoc.TuKhoa,
            NgonNgu = congBoKhoaHoc.NgonNgu,
            LoaiCongBo = congBoKhoaHoc.LoaiCongBo,
            ISSN_ISBN = congBoKhoaHoc.ISSN_ISBN,
            ChiMucKhoaHoc = congBoKhoaHoc.ChiMucKhoaHoc,
            ImpactFactor = congBoKhoaHoc.ImpactFactor,
            DOI = congBoKhoaHoc.DOI,
            NamCongBo = congBoKhoaHoc.NamCongBo,
            SoTrang = congBoKhoaHoc.SoTrang,
            FileDinhKem = congBoKhoaHoc.FileDinhKem,
        };
        await _congBoKhoaHocRepository.AddCongBoKhoaHocAsync(congBoKhoaHocEntity);
        return true;
    }
    
    public async Task<bool> UpdateStatus(int id, CBKHStatus status)
    {
        var congBoKhoaHocEntity = await _congBoKhoaHocRepository.GetCongBoKhoaHocAsync(id);
        congBoKhoaHocEntity.TrangThai = status.TrangThai;
        await _congBoKhoaHocRepository.UpdateCongBoKhoaHocAsync(congBoKhoaHocEntity);
        return true;
    }

    public async Task<bool> UpdateCongBoKhoaHocAsync(int id, CongBoKhoaHocCRUD congBoKhoaHoc)
    {
        var congBoKhoaHocEntity = await _congBoKhoaHocRepository.GetCongBoKhoaHocAsync(id);
        congBoKhoaHocEntity.MaCongBo = congBoKhoaHoc.MaCongBo;
        congBoKhoaHocEntity.TieuDe = congBoKhoaHoc.TieuDe;
        congBoKhoaHocEntity.TomTat = congBoKhoaHoc.TomTat;
        congBoKhoaHocEntity.TuKhoa = congBoKhoaHoc.TuKhoa;
        congBoKhoaHocEntity.NgonNgu = congBoKhoaHoc.NgonNgu;
        congBoKhoaHocEntity.LoaiCongBo = congBoKhoaHoc.LoaiCongBo;
        congBoKhoaHocEntity.ISSN_ISBN = congBoKhoaHoc.ISSN_ISBN;
        congBoKhoaHocEntity.ChiMucKhoaHoc = congBoKhoaHoc.ChiMucKhoaHoc;
        congBoKhoaHocEntity.ImpactFactor = congBoKhoaHoc.ImpactFactor;
        congBoKhoaHocEntity.DOI = congBoKhoaHoc.DOI;
        congBoKhoaHocEntity.NamCongBo = congBoKhoaHoc.NamCongBo;
        congBoKhoaHocEntity.SoTrang = congBoKhoaHoc.SoTrang;
        congBoKhoaHocEntity.FileDinhKem = congBoKhoaHoc.FileDinhKem;
        await _congBoKhoaHocRepository.UpdateCongBoKhoaHocAsync(congBoKhoaHocEntity);
        return true;
    }

    public async Task<bool> DeleteCongBoKhoaHocAsync(int id)
    {
        var congBoKhoaHocEntity = await _congBoKhoaHocRepository.GetCongBoKhoaHocAsync(id);
        await _congBoKhoaHocRepository.DeleteCongBoKhoaHocAsync(congBoKhoaHocEntity);
        return true;
    }
}

