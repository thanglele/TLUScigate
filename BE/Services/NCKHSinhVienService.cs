using TLUScience.DTOs;
using TLUScience.Entities;
using TLUScience.Interface;

public interface INCKHSinhVienService
{
    public Task<List<NCKHSinhVienDTO>> GetFullNCKHSinhVienAsync();
    public Task<CNKHSinhVienGet> GetNCKHSinhVienAsync(int id);
    public Task<bool> AddNCKHSinhVienAsync(NCKHSinhVienCRUD nCKHSinhVien);
    public Task<bool> UpdateNCKHSinhVienAsync(int id, NCKHSinhVienCRUD nCKHSinhVien);
    public Task<bool> DeleteNCKHSinhVienAsync(int id);
    public Task<bool> UpdateStatus(int id, Status status);
}

public class NCKHSinhVienService : INCKHSinhVienService
{
    private readonly INCKHSinhVienRepository _CKHSinhVienRepository;
    private readonly ISinhVienNCKHRepository _SinhVienNCKHRepository;
    private readonly IGiangVienRepository _GiangVienRepository;
    private readonly ISinhVienRepository _SinhVienRepository;
    public NCKHSinhVienService(INCKHSinhVienRepository CKHSinhVienRepository, ISinhVienNCKHRepository SinhVienNCKHRepository, IGiangVienRepository GiangVienRepository, ISinhVienRepository SinhVienRepository)
    {
        _SinhVienRepository = SinhVienRepository;
        _GiangVienRepository = GiangVienRepository;
        _CKHSinhVienRepository = CKHSinhVienRepository;
        _SinhVienNCKHRepository = SinhVienNCKHRepository;
    }


    public async Task<List<NCKHSinhVienDTO>> GetFullNCKHSinhVienAsync()
    {
        var nCKHSinhViens = await _CKHSinhVienRepository.GetFullNCKHSinhVienAsync();
        var sinhVienNCKHs = await _SinhVienNCKHRepository.GetFullSinhVienNCKHAsync();
        var giangViens = await _GiangVienRepository.GetFullGiangVienAsync();
        var sinhViens = await _SinhVienRepository.GetFullSinhVienAsync();

        // Bước 1: Tìm mã sinh viên từ mã nghiên cứu khoa học
        var maSinhVien = nCKHSinhViens.Select(nckh => sinhVienNCKHs.FirstOrDefault(svnckh => svnckh.MaNCKH == nckh.MaNCKH)?.MaSV).FirstOrDefault();

        // Bước 2: Nếu tìm thấy mã sinh viên, lấy họ tên của sinh viên đó
        var truongNhom = sinhViens.FirstOrDefault(sv => sv.MaSV == maSinhVien)?.HoTen ?? string.Empty;

        return nCKHSinhViens.Select(nCKHSinhVien =>
        {
            return new NCKHSinhVienDTO
            {
                ID = nCKHSinhVien.ID,
                MaNCKH = nCKHSinhVien.MaNCKH,
                TenHoatDong = nCKHSinhVien.TenHoatDong ?? string.Empty,
                NgayBatDau = nCKHSinhVien.NgayBatDau,
                NgayKetThuc = nCKHSinhVien.NgayKetThuc,
                TenGiangVien = giangViens.FirstOrDefault(gv => gv.MaGV == nCKHSinhVien.GiangVienHuongDan)?.HoTen ?? string.Empty,
                TruongNhom = truongNhom,
                KetQua = nCKHSinhVien.KetQua ?? string.Empty,
                TrangThai = nCKHSinhVien.TrangThai ?? string.Empty,
                KinhPhiHd = nCKHSinhVien.KinhPhiHoatDong,
                DiaDiem = nCKHSinhVien.DiaDiem ?? string.Empty,
                FileHoanThanh = nCKHSinhVien.FileHoanThanh ?? string.Empty,
            };
        }).ToList();
    }

    public async Task<CNKHSinhVienGet> GetNCKHSinhVienAsync(int id)
    {
        var nCKHSinhVien = await _CKHSinhVienRepository.GetNCKHSinhVienAsync(id);
        var sinhVienNCKHs = await _SinhVienNCKHRepository.GetFullSinhVienNCKHAsync();
        var giangViens = await _GiangVienRepository.GetFullGiangVienAsync();
        var sinhViens = await _SinhVienRepository.GetFullSinhVienAsync();

        // Bước 1: Tìm mã sinh viên từ mã nghiên cứu khoa học
        var maSinhVien = sinhVienNCKHs.FirstOrDefault(svnckh => svnckh.MaNCKH == nCKHSinhVien.MaNCKH)?.MaSV;

        // Bước 2: Nếu tìm thấy mã sinh viên, lấy họ tên của sinh viên đó
        var truongNhom = sinhViens.FirstOrDefault(sv => sv.MaSV == maSinhVien)?.HoTen ?? string.Empty;

        return new CNKHSinhVienGet
        {
            MaNCKH = nCKHSinhVien.MaNCKH,
            TenHoatDong = nCKHSinhVien.TenHoatDong ?? string.Empty,
            NgayBatDau = nCKHSinhVien.NgayBatDau,
            NgayKetThuc = nCKHSinhVien.NgayKetThuc,
            TenGiangVien = giangViens.FirstOrDefault(gv => gv.MaGV == nCKHSinhVien.GiangVienHuongDan)?.HoTen ?? string.Empty,
            TruongNhom = truongNhom,
            KetQua = nCKHSinhVien.KetQua ?? string.Empty,
            TrangThai = nCKHSinhVien.TrangThai ?? string.Empty,
            KinhPhiHd = nCKHSinhVien.KinhPhiHoatDong,
            DiaDiem = nCKHSinhVien.DiaDiem ?? string.Empty,
        };
    }

    public async Task<bool> AddNCKHSinhVienAsync(NCKHSinhVienCRUD nCKHSinhVien)
    {
        var sinhVienNCKHs = await _SinhVienNCKHRepository.GetFullSinhVienNCKHAsync();

        var nCKHSinhVienEntity = new NghienCuuKhoaHocSinhVien
        {
            MaNCKH = nCKHSinhVien.MaNCKH,
            TenHoatDong = nCKHSinhVien.TenHoatDong,
            GiangVienHuongDan = nCKHSinhVien.TenGiangVien,
            NgayBatDau = nCKHSinhVien.NgayBatDau,
            NgayKetThuc = nCKHSinhVien.NgayKetThuc,
            TrangThai = nCKHSinhVien.TrangThai,
            KetQua = nCKHSinhVien.KetQua,
            KinhPhiHoatDong = nCKHSinhVien.KinhPhiHd,
            DiaDiem = nCKHSinhVien.DiaDiem,
            FileHoanThanh = nCKHSinhVien.FileHoanThanh,
        };

        await _CKHSinhVienRepository.AddNCKHSinhVienAsync(nCKHSinhVienEntity);
        return true;
    }

    public async Task<bool> UpdateStatus(int id, Status status)
    {
        var nCKHSinhVienEntity = await _CKHSinhVienRepository.GetNCKHSinhVienAsync(id);
        if (nCKHSinhVienEntity == null)
        {
            return false;
        }

        nCKHSinhVienEntity.TrangThai = status.TrangThai;

        await _CKHSinhVienRepository.UpdateNCKHSinhVienAsync(nCKHSinhVienEntity);
        return true;
    }

    public async Task<bool> UpdateNCKHSinhVienAsync(int id, NCKHSinhVienCRUD nCKHSinhVien)
    {
        var nCKHSinhVienEntity = await _CKHSinhVienRepository.GetNCKHSinhVienAsync(id);
        if (nCKHSinhVienEntity == null)
        {
            return false;
        }

        nCKHSinhVienEntity.MaNCKH = nCKHSinhVien.MaNCKH;
        nCKHSinhVienEntity.TenHoatDong = nCKHSinhVien.TenHoatDong;
        nCKHSinhVienEntity.GiangVienHuongDan = nCKHSinhVien.TenGiangVien;
        nCKHSinhVienEntity.NgayBatDau = nCKHSinhVien.NgayBatDau;
        nCKHSinhVienEntity.NgayKetThuc = nCKHSinhVien.NgayKetThuc;
        nCKHSinhVienEntity.TrangThai = nCKHSinhVien.TrangThai;
        nCKHSinhVienEntity.KetQua = nCKHSinhVien.KetQua;
        nCKHSinhVienEntity.KinhPhiHoatDong = nCKHSinhVien.KinhPhiHd;
        nCKHSinhVienEntity.DiaDiem = nCKHSinhVien.DiaDiem;
        nCKHSinhVienEntity.FileHoanThanh = nCKHSinhVien.FileHoanThanh;

        await _CKHSinhVienRepository.UpdateNCKHSinhVienAsync(nCKHSinhVienEntity);
        return true;
    }

    public async Task<bool> DeleteNCKHSinhVienAsync(int id)
    {
        var nCKHSinhVienEntity = await _CKHSinhVienRepository.GetNCKHSinhVienAsync(id);
        if (nCKHSinhVienEntity == null)
        {
            return false;
        }

        await _CKHSinhVienRepository.DeleteNCKHSinhVienAsync(nCKHSinhVienEntity);
        return true;
    }
}