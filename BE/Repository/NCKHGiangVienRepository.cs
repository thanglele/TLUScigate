using Microsoft.EntityFrameworkCore;
using TLUScience.Entities;

namespace TLUScience.Repository
{
    public interface INCKHGiangVienRepository
    {
        public Task<List<DeTaiNghienCuu>> GetFullNCKHGiangVienAsync();
        public Task<DeTaiNghienCuu> GetNCKHGiangVienAsync(int id);
        public Task<DeTaiNghienCuu?> GetByIdAsync(int id);
        public Task<DeTaiNghienCuu> AddNCKHGiangVienAsync(DeTaiNghienCuu nCKHGiangVien);
        public Task<DeTaiNghienCuu> UpdateNCKHGiangVienAsync(DeTaiNghienCuu nCKHGiangVien);
        public Task<bool> DeleteNCKHGiangVienAsync(DeTaiNghienCuu nCKHGiangVien);
    }
    public class NCKHGiangVienRepository : INCKHGiangVienRepository
    {
        private readonly AppDbContext _context;
        public NCKHGiangVienRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<DeTaiNghienCuu>> GetFullNCKHGiangVienAsync()
        {
            return await _context.DeTaiNghienCuus.ToListAsync();
        }

        public async Task<DeTaiNghienCuu> GetNCKHGiangVienAsync(int id)
        {
            return await _context.DeTaiNghienCuus.FindAsync(id) ?? throw new InvalidOperationException("Không tìm thấy nghiên cứu khoa học sinh viên này!");
        }
        public async Task<DeTaiNghienCuu?> GetByIdAsync(int id)
        {
            return await _context.DeTaiNghienCuus
                .Include(n => n.ID_LinhVucs)
                .Include(n => n.ThanhVienDeTais)
                .FirstOrDefaultAsync(n => n.ID == id);
        }

        public async Task<DeTaiNghienCuu> AddNCKHGiangVienAsync(DeTaiNghienCuu nCKHGiangVien)
        {
            _context.DeTaiNghienCuus.Add(nCKHGiangVien);
            await _context.SaveChangesAsync();
            return nCKHGiangVien;
        }

        public async Task<DeTaiNghienCuu> UpdateNCKHGiangVienAsync(DeTaiNghienCuu nCKHGiangVien)
        {
            _context.DeTaiNghienCuus.Update(nCKHGiangVien);
            await _context.SaveChangesAsync();
            return nCKHGiangVien;
        }

        public async Task<bool> DeleteNCKHGiangVienAsync(DeTaiNghienCuu nckhGiangVien)
        {
            if (nckhGiangVien == null) return false;

            // Xóa liên kết lĩnh vực nghiên cứu
            nckhGiangVien.ID_LinhVucs.Clear();

            // Xóa danh sách thành viên tham gia
            _context.ThanhVienDeTais.RemoveRange(nckhGiangVien.ThanhVienDeTais);

            // Xóa bản ghi chính
            _context.DeTaiNghienCuus.Remove(nckhGiangVien);

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
