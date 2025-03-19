using Microsoft.EntityFrameworkCore;
using TLUScience.Entities;

namespace TLUScience.Interface;

public interface IDeTaiNghienCuuRepository
{
    public Task<List<DeTaiNghienCuu>> GetFullDeTaiNghienCuuAsync();
    public Task<DeTaiNghienCuu> GetDeTaiNghienCuuAsync(int id);
    public Task<DeTaiNghienCuu> AddDeTaiNghienCuuAsync(DeTaiNghienCuu deTaiNghienCuu);
    public Task<DeTaiNghienCuu> UpdateDeTaiNghienCuuAsync(DeTaiNghienCuu deTaiNghienCuu);
    public Task<bool> DeleteDeTaiNghienCuuAsync(DeTaiNghienCuu deTaiNghienCuu);
}

public class DeTaiNghienCuuRepository : IDeTaiNghienCuuRepository
{
    private readonly AppDbContext _context;

    public DeTaiNghienCuuRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<DeTaiNghienCuu>> GetFullDeTaiNghienCuuAsync()
    {
        return await _context.DeTaiNghienCuus.ToListAsync();
    }

    public async Task<DeTaiNghienCuu> GetDeTaiNghienCuuAsync(int id)
    {
        return await _context.DeTaiNghienCuus.FindAsync(id) ?? throw new InvalidOperationException("Không tìm thấy đề tài nghiên cứu này!");
    }

    public async Task<DeTaiNghienCuu> AddDeTaiNghienCuuAsync(DeTaiNghienCuu deTaiNghienCuu)
    {
        _context.DeTaiNghienCuus.Add(deTaiNghienCuu);
        await _context.SaveChangesAsync();
        return deTaiNghienCuu;
    }

    public async Task<DeTaiNghienCuu> UpdateDeTaiNghienCuuAsync(DeTaiNghienCuu deTaiNghienCuu)
    {
        _context.DeTaiNghienCuus.Update(deTaiNghienCuu);
        await _context.SaveChangesAsync();
        return deTaiNghienCuu;
    }

    public async Task<bool> DeleteDeTaiNghienCuuAsync(DeTaiNghienCuu deTaiNghienCuu)
    {
        _context.DeTaiNghienCuus.Remove(deTaiNghienCuu);
        await _context.SaveChangesAsync();
        return true;
    }

}