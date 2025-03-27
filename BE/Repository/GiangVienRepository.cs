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
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<List<GiangVien>> GetFullGiangVienAsync()
    {
        return await _context.GiangViens
            .Include(g => g.TaiKhoan)
            .Include(g => g.MaBoMonNavigation)
            .ToListAsync();
    }

    public async Task<GiangVien> GetGiangVienAsync(int id)
    {
        return await _context.GiangViens
            .Include(g => g.TaiKhoan)
            .Include(g => g.MaBoMonNavigation)
            .FirstOrDefaultAsync(g => g.ID == id);
    }

    public async Task<GiangVien> AddGiangVienAsync(GiangVien giangVien)
    {
        await _context.GiangViens.AddAsync(giangVien);
        await _context.SaveChangesAsync();
        return giangVien;
    }

    public async Task<GiangVien> UpdateGiangVienAsync(GiangVien giangVien)
    {
        _context.Entry(giangVien).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return giangVien;
    }

    public async Task<bool> DeleteGiangVienAsync(GiangVien giangVien)
    {
        _context.GiangViens.Remove(giangVien);
        var result = await _context.SaveChangesAsync();
        return result > 0;
    }
}
