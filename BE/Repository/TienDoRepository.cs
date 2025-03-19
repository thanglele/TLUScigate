using Microsoft.EntityFrameworkCore;
using TLUScience.Entities;

namespace TLUScience.Interface;

public interface ITienDoRepository
{
    public Task<List<TienDo>> GetFullTienDoAsync();
    public Task<TienDo> GetTienDoAsync(int id);
    public Task<TienDo> AddTienDoAsync(TienDo tienDo);
    public Task<TienDo> UpdateTienDoAsync(TienDo tienDo);
    public Task<bool> DeleteTienDoAsync(TienDo tienDo);
}

public class TienDoRepository : ITienDoRepository
{
    private readonly AppDbContext _context;

    public TienDoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TienDo>> GetFullTienDoAsync()
    {
        return await _context.TienDos.ToListAsync();
    }

    public async Task<TienDo> GetTienDoAsync(int id)
    {
        return await _context.TienDos.FindAsync(id) ?? throw new InvalidOperationException("Không tìm thấy tiến độ này!");
    }

    public async Task<TienDo> AddTienDoAsync(TienDo tienDo)
    {
        _context.TienDos.Add(tienDo);
        await _context.SaveChangesAsync();
        return tienDo;
    }

    public async Task<TienDo> UpdateTienDoAsync(TienDo tienDo)
    {
        _context.TienDos.Update(tienDo);
        await _context.SaveChangesAsync();
        return tienDo;
    }

    public async Task<bool> DeleteTienDoAsync(TienDo tienDo)
    {
        _context.TienDos.Remove(tienDo);
        await _context.SaveChangesAsync();
        return true;
    }
}