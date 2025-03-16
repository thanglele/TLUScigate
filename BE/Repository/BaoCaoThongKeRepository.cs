using TLUScience.Entities;

namespace TLUScience.Interface;

public interface IBaoCaoThongKeRepository
{
    //public Task<List<BaoCaoThongKe>> GetFullBaoCaoThongKeAsync();
    public Task<BaoCaoThongKe> GetBaoCaoThongKeAsync(int id);
    public Task<BaoCaoThongKe> AddBaoCaoThongKeAsync(BaoCaoThongKe baoCaoThongKe);
    //public Task<BaoCaoThongKe> UpdateBaoCaoThongKeAsync(BaoCaoThongKe baoCaoThongKe);
    //public Task<bool> DeleteBaoCaoThongKeAsync(BaoCaoThongKe baoCaoThongKe);
}

public class BaoCaoThongKeRepository:IBaoCaoThongKeRepository
{
    private readonly AppDbContext _context;
    public BaoCaoThongKeRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<BaoCaoThongKe> GetBaoCaoThongKeAsync(int id)
    {
        return await _context.BaoCaoThongKes.FindAsync(id);
    }

    public async Task<BaoCaoThongKe> AddBaoCaoThongKeAsync(BaoCaoThongKe baoCaoThongKe)
    {
        _context.BaoCaoThongKes.Add(baoCaoThongKe);
        await _context.SaveChangesAsync();
        return baoCaoThongKe;
    }
}