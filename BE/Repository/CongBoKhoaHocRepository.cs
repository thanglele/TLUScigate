using Microsoft.EntityFrameworkCore;
using TLUScience.Entities;

namespace TLUScience.Interface
{
    public interface ICongBoKhoaHocRepository
    {
        public Task<List<CongBoKhoaHoc>> GetFullCongBoKhoaHocAsync();
        public Task<CongBoKhoaHoc> GetCongBoKhoaHocAsync(int id);
        public Task<CongBoKhoaHoc> AddCongBoKhoaHocAsync(CongBoKhoaHoc congBoKhoaHoc);
        public Task<CongBoKhoaHoc> UpdateCongBoKhoaHocAsync(CongBoKhoaHoc congBoKhoaHoc);
        public Task<bool> DeleteCongBoKhoaHocAsync(CongBoKhoaHoc congBoKhoaHoc);
    }

    public class CongBoKhoaHocRepository : ICongBoKhoaHocRepository
    {
        private readonly AppDbContext _context;

        public CongBoKhoaHocRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<CongBoKhoaHoc>> GetFullCongBoKhoaHocAsync()
        {
            return await _context.CongBoKhoaHocs.ToListAsync();
        }

        public async Task<CongBoKhoaHoc> GetCongBoKhoaHocAsync(int id)
        {
            return await _context.CongBoKhoaHocs.FindAsync(id) ?? throw new InvalidOperationException("Không tìm thấy công bố khoa học này!");
        }

        public async Task<CongBoKhoaHoc> AddCongBoKhoaHocAsync(CongBoKhoaHoc congBoKhoaHoc)
        {
            _context.CongBoKhoaHocs.Add(congBoKhoaHoc);
            await _context.SaveChangesAsync();
            return congBoKhoaHoc;
        }

        public async Task<CongBoKhoaHoc> UpdateCongBoKhoaHocAsync(CongBoKhoaHoc congBoKhoaHoc)
        {
            _context.CongBoKhoaHocs.Update(congBoKhoaHoc);
            await _context.SaveChangesAsync();
            return congBoKhoaHoc;
        }

        public async Task<bool> DeleteCongBoKhoaHocAsync(CongBoKhoaHoc congBoKhoaHoc)
        {
            _context.CongBoKhoaHocs.Remove(congBoKhoaHoc);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}