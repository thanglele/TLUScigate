using Microsoft.EntityFrameworkCore;
using TLUScience.Entities;

namespace TLUScience.Interface;

public interface INCKHSinhVienRepository
{
    public Task<List<NghienCuuKhoaHocSinhVien>> GetFullNCKHSinhVienAsync();
    public Task<NghienCuuKhoaHocSinhVien> GetNCKHSinhVienAsync(int id);
    public Task<NghienCuuKhoaHocSinhVien> AddNCKHSinhVienAsync(NghienCuuKhoaHocSinhVien nCKHSinhVien);
    public Task<NghienCuuKhoaHocSinhVien> UpdateNCKHSinhVienAsync(NghienCuuKhoaHocSinhVien nCKHSinhVien);
    public Task<bool> DeleteNCKHSinhVienAsync(NghienCuuKhoaHocSinhVien nCKHSinhVien);
}

public class NCKHSinhVienRepository:INCKHSinhVienRepository
{
    private readonly AppDbContext _context;
    public NCKHSinhVienRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<NghienCuuKhoaHocSinhVien>> GetFullNCKHSinhVienAsync()
    {
        return await _context.NghienCuuKhoaHocSinhViens.ToListAsync();
    }

    public async Task<NghienCuuKhoaHocSinhVien> GetNCKHSinhVienAsync(int id)
    {
        return await _context.NghienCuuKhoaHocSinhViens.FindAsync(id) ?? throw new InvalidOperationException("Không tìm thấy nghiên cứu khoa học sinh viên này!");
    }

    public async Task<NghienCuuKhoaHocSinhVien> AddNCKHSinhVienAsync(NghienCuuKhoaHocSinhVien nCKHSinhVien)
    {
        _context.NghienCuuKhoaHocSinhViens.Add(nCKHSinhVien);
        await _context.SaveChangesAsync();
        return nCKHSinhVien;
    }

    public async Task<NghienCuuKhoaHocSinhVien> UpdateNCKHSinhVienAsync(NghienCuuKhoaHocSinhVien nCKHSinhVien)
    {
        _context.NghienCuuKhoaHocSinhViens.Update(nCKHSinhVien);
        await _context.SaveChangesAsync();
        return nCKHSinhVien;
    }

    public async Task<bool> DeleteNCKHSinhVienAsync(NghienCuuKhoaHocSinhVien nCKHSinhVien)
    {
        _context.NghienCuuKhoaHocSinhViens.Remove(nCKHSinhVien);
        await _context.SaveChangesAsync();
        return true;
    }
}