using Microsoft.EntityFrameworkCore;
using TLUScience.Entities;

namespace TLUScience.Interface;

public interface ISinhVienNCKHRepository
{
    public Task<List<SinhVienNCKH>> GetFullSinhVienNCKHAsync();
    public Task<SinhVienNCKH> GetSinhVienNCKHAsync(int id);
    public Task<SinhVienNCKH> AddSinhVienNCKHAsync(SinhVienNCKH sinhVienNCKH);
    public Task<SinhVienNCKH> UpdateSinhVienNCKHAsync(SinhVienNCKH sinhVienNCKH);
    public Task<bool> DeleteSinhVienNCKHAsync(SinhVienNCKH sinhVienNCKH);
}

public class SinhVienNCKHRepository : ISinhVienNCKHRepository
{
    private readonly AppDbContext _context;

    public SinhVienNCKHRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<SinhVienNCKH>> GetFullSinhVienNCKHAsync()
    {
        return await _context.SinhVienNCKHs.ToListAsync();
    }

    public async Task<SinhVienNCKH> GetSinhVienNCKHAsync(int id)
    {
        return await _context.SinhVienNCKHs.FindAsync(id) ?? throw new InvalidOperationException("Không tìm thấy sinh viên nghiên cứu khoa học này!");
    }

    public async Task<SinhVienNCKH> AddSinhVienNCKHAsync(SinhVienNCKH sinhVienNCKH)
    {
        _context.SinhVienNCKHs.Add(sinhVienNCKH);
        await _context.SaveChangesAsync();
        return sinhVienNCKH;
    }

    public async Task<SinhVienNCKH> UpdateSinhVienNCKHAsync(SinhVienNCKH sinhVienNCKH)
    {
        _context.SinhVienNCKHs.Update(sinhVienNCKH);
        await _context.SaveChangesAsync();
        return sinhVienNCKH;
    }

    public async Task<bool> DeleteSinhVienNCKHAsync(SinhVienNCKH sinhVienNCKH)
    {
        _context.SinhVienNCKHs.Remove(sinhVienNCKH);
        await _context.SaveChangesAsync();
        return true;
    }
}