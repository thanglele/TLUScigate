using Microsoft.EntityFrameworkCore;
using TLUScience.Entities;

namespace TLUScience.Interface;

public interface ITacGiaCongBoRepository
{
    public Task<List<TacGiaCongBo>> GetFullTacGiaCongBoAsync();
    public Task<TacGiaCongBo> GetTacGiaCongBoAsync(int id);
    public Task<bool> AddTacGiaCongBoAsync(TacGiaCongBo tacGiaCongBo);
    public Task<bool> UpdateTacGiaCongBoAsync(TacGiaCongBo tacGiaCongBo);
    public Task<bool> DeleteTacGiaCongBoAsync(TacGiaCongBo tacGiaCongBo);
}

public class TacGiaCongBoRepository : ITacGiaCongBoRepository
{
    private readonly AppDbContext _context;

    public TacGiaCongBoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TacGiaCongBo>> GetFullTacGiaCongBoAsync()
    {
        return await _context.TacGiaCongBos.ToListAsync();
    }

    public async Task<TacGiaCongBo> GetTacGiaCongBoAsync(int id)
    {
        return await _context.TacGiaCongBos.FindAsync(id);
    }

    public async Task<bool> AddTacGiaCongBoAsync(TacGiaCongBo tacGiaCongBo)
    {
        _context.TacGiaCongBos.Add(tacGiaCongBo);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> UpdateTacGiaCongBoAsync(TacGiaCongBo tacGiaCongBo)
    {
        _context.TacGiaCongBos.Update(tacGiaCongBo);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteTacGiaCongBoAsync(TacGiaCongBo tacGiaCongBo)
    {
        _context.TacGiaCongBos.Remove(tacGiaCongBo);
        await _context.SaveChangesAsync();
        return true;
    }
}