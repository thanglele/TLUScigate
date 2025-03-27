using Microsoft.EntityFrameworkCore;
using TLUScience.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TLUScience.Repository
{
    public interface INCKHGiangVienRepository
    {
        Task<List<DeTaiNghienCuu>> GetFullNCKHGiangVienAsync();
        Task<DeTaiNghienCuu?> GetByIdAsync(int id);
        Task<DeTaiNghienCuu> AddNCKHGiangVienAsync(DeTaiNghienCuu nCKHGiangVien);
        Task<DeTaiNghienCuu> UpdateNCKHGiangVienAsync(DeTaiNghienCuu nCKHGiangVien);
        Task<bool> DeleteNCKHGiangVienAsync(DeTaiNghienCuu nCKHGiangVien);
    }

    public class NCKHGiangVienRepository : INCKHGiangVienRepository
    {
        private readonly AppDbContext _context;

        public NCKHGiangVienRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<DeTaiNghienCuu>> GetFullNCKHGiangVienAsync()
        {
            return await _context.DeTaiNghienCuus
                .Include(dt => dt.ChuNhiemDeTaiNavigation)
                    .ThenInclude(gv => gv.MaBoMonNavigation)
                        .ThenInclude(bm => bm.MaKhoaNavigation)
                .Include(dt => dt.ID_LinhVucs)
                .Include(dt => dt.ThanhVienDeTais)
                    .ThenInclude(tv => tv.MaGVNavigation)
                        .ThenInclude(gv => gv.MaBoMonNavigation)
                            .ThenInclude(bm => bm.MaKhoaNavigation)
                .ToListAsync();
        }

        public async Task<DeTaiNghienCuu?> GetByIdAsync(int id)
        {
            return await _context.DeTaiNghienCuus
                .Include(dt => dt.ChuNhiemDeTaiNavigation)
                    .ThenInclude(gv => gv.MaBoMonNavigation)
                        .ThenInclude(bm => bm.MaKhoaNavigation)
                .Include(dt => dt.ID_LinhVucs)
                .Include(dt => dt.ThanhVienDeTais)
                    .ThenInclude(tv => tv.MaGVNavigation)
                        .ThenInclude(gv => gv.MaBoMonNavigation)
                            .ThenInclude(bm => bm.MaKhoaNavigation)
                .FirstOrDefaultAsync(dt => dt.ID == id);
        }

        public async Task<DeTaiNghienCuu> AddNCKHGiangVienAsync(DeTaiNghienCuu nCKHGiangVien)
        {
            await _context.DeTaiNghienCuus.AddAsync(nCKHGiangVien);
            await _context.SaveChangesAsync();
            return nCKHGiangVien;
        }

        public async Task<DeTaiNghienCuu> UpdateNCKHGiangVienAsync(DeTaiNghienCuu nCKHGiangVien)
        {
            _context.Entry(nCKHGiangVien).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return nCKHGiangVien;
        }

        public async Task<bool> DeleteNCKHGiangVienAsync(DeTaiNghienCuu nckhGiangVien)
        {
            if (nckhGiangVien == null) return false;

            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Xóa liên kết lĩnh vực nghiên cứu
                nckhGiangVien.ID_LinhVucs.Clear();

                // Xóa danh sách thành viên tham gia
                _context.ThanhVienDeTais.RemoveRange(nckhGiangVien.ThanhVienDeTais);

                // Xóa bản ghi chính
                _context.DeTaiNghienCuus.Remove(nckhGiangVien);

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();
                return true;
            }
            catch
            {
                await transaction.RollbackAsync();
                return false;
            }
        }
    }
}
