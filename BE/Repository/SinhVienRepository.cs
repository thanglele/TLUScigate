using Microsoft.EntityFrameworkCore;
using TLUScience.Entities;

namespace TLUScience.Interface;

public interface ISinhVienRepository
{
    public Task<List<SinhVien>> GetFullSinhVienAsync();
    public Task<SinhVien> GetSinhVienAsync(int id);
    public Task<SinhVien> AddSinhVienAsync(SinhVien sinhVien);
    public Task<SinhVien> UpdateSinhVienAsync(SinhVien sinhVien);
    public Task<bool> DeleteSinhVienAsync(SinhVien sinhVien);
}

public class SinhVienRepository: ISinhVienRepository
{
    private readonly AppDbContext _context;

    public SinhVienRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<SinhVien>> GetFullSinhVienAsync()
    {
        return await _context.SinhViens.ToListAsync();
    }

    public async Task<SinhVien> GetSinhVienAsync(int id)
    {
        return await _context.SinhViens.FindAsync(id) ?? throw new InvalidOperationException("Không tìm thấy sinh viên này!");
    }

    public async Task<SinhVien> AddSinhVienAsync(SinhVien sinhVien)
    {
        _context.SinhViens.Add(sinhVien);
        await _context.SaveChangesAsync();
        return sinhVien;
    }

    public async Task<SinhVien> UpdateSinhVienAsync(SinhVien sinhVien)
    {
        _context.SinhViens.Update(sinhVien);
        await _context.SaveChangesAsync();
        return sinhVien;
    }

    public async Task<bool> DeleteSinhVienAsync(SinhVien sinhVien)
    {
        _context.SinhViens.Remove(sinhVien);
        await _context.SaveChangesAsync();
        return true;
    }
}
