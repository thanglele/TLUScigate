using Microsoft.EntityFrameworkCore;
using TLUScience.Entities;

namespace TLUScience.Interface;

public interface IGiangVienRepository
{
    public Task<List<GiangVien>> GetFullGiangVienAsync();
    public Task<GiangVien> GetGiangVienAsync(int id);
    public Task<GiangVien> AddGiangVienAsync(GiangVien giangVien);
    public Task<GiangVien> UpdateGiangVienAsync(GiangVien giangVien);
    public Task<bool> DeleteGiangVienAsync(GiangVien giangVien);
}

public class GiangVienRepository : IGiangVienRepository
{
    private readonly AppDbContext _context;

    public GiangVienRepository(AppDbContext context)
    {
        if (context == null)
        {
            throw new InvalidOperationException("AppDbContext chưa được inject vào GiangVienRepository!");
        }
        _context = context;
    }

    public async Task<List<GiangVien>> GetFullGiangVienAsync()
    {
        return await _context.GiangViens.ToListAsync();
    }

    public async Task<GiangVien> GetGiangVienAsync(int id)
    {
        return await _context.GiangViens.FindAsync(id);
    }

    public async Task<GiangVien> AddGiangVienAsync(GiangVien giangVien)
    {
        _context.GiangViens.Add(giangVien);
        await _context.SaveChangesAsync();
        return giangVien;
    }

    public async Task<GiangVien> UpdateGiangVienAsync(GiangVien giangVien)
    {
        _context.GiangViens.Update(giangVien);
        await _context.SaveChangesAsync();
        return giangVien;
    }

    public async Task<bool> DeleteGiangVienAsync(GiangVien giangVien)
    {
        _context.GiangViens.Remove(giangVien);
        await _context.SaveChangesAsync();
        return true;
    }
}
