
using Microsoft.EntityFrameworkCore;
using TLUScience.Entities;

namespace TLUScience.Interface;

public interface ITapChiAnPhamRepository
{
    public Task<List<TapChiAnPham>> GetFullTapChiAnPhamAsync();
    public Task<TapChiAnPham> GetTapChiAnPhamAsync(int id);
    public Task<TapChiAnPham> AddTapChiAnPhamAsync(TapChiAnPham tapChiAnPham);
    public Task<TapChiAnPham> UpdateTapChiAnPhamAsync(TapChiAnPham tapChiAnPham);
    public Task<bool> DeleteTapChiAnPhamAsync(TapChiAnPham tapChiAnPham);
}

public class TapChiAnPhamRepository : ITapChiAnPhamRepository
{
    private readonly AppDbContext _context;

    public TapChiAnPhamRepository(AppDbContext context)
    {
        if (context == null)
        {
            throw new InvalidOperationException("AppDbContext chưa được inject vào TapChiAnPhamRepository!");
        }
        _context = context;
    }

    public async Task<List<TapChiAnPham>> GetFullTapChiAnPhamAsync()
    {
        return await _context.TapChiAnPhams.ToListAsync();
    }

    public async Task<TapChiAnPham> GetTapChiAnPhamAsync(int id)
    {
        return await _context.TapChiAnPhams.FindAsync(id) ?? throw new InvalidOperationException("Không tìm thấy tạp chí ấn phẩm này!");
    }

    public async Task<TapChiAnPham> AddTapChiAnPhamAsync(TapChiAnPham tapChiAnPham)
    {
        _context.TapChiAnPhams.Add(tapChiAnPham);
        await _context.SaveChangesAsync();
        return tapChiAnPham;
    }

    public async Task<TapChiAnPham> UpdateTapChiAnPhamAsync(TapChiAnPham tapChiAnPham)
    {
        _context.TapChiAnPhams.Update(tapChiAnPham);
        await _context.SaveChangesAsync();
        return tapChiAnPham;
    }

    public async Task<bool> DeleteTapChiAnPhamAsync(TapChiAnPham tapChiAnPham)
    {
        _context.TapChiAnPhams.Remove(tapChiAnPham);
        await _context.SaveChangesAsync();
        return true;
    }
}

