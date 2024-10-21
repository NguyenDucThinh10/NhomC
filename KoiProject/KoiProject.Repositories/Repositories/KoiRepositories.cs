using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiProject.Repositories.Repositories
{
    public class KoiRepositories : IKoiRepository
    {
        private readonly FengShuiKoiDbContext _dbContext;

        public KoiRepositories(FengShuiKoiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Lấy thông tin cá Koi theo ID, có thể trả về null
        public async Task<Koi?> GetByIdAsync(int id)
        {
            return await _dbContext.Kois.FindAsync(id);

        }

        // Lấy danh sách tất cả các cá Koi
        public async Task<List<Koi>> GetKois()
        {
            List<Koi> kois = new(); // Khởi tạo danh sách trống
            try
            {
                kois = await _dbContext.Kois.ToListAsync();
            }
            catch (Exception ex)
            {
                // Ghi log ngoại lệ (nếu cần) và trả về danh sách trống
                Console.WriteLine(ex.Message);
            }
            return kois; // Luôn trả về danh sách (trống nếu có lỗi)
        }

        // Thêm cá Koi mới
        public void Add(Koi koi)
        {
            _dbContext.Kois.Add(koi);
        }

        // Xóa cá Koi
        public void Remove(Koi koi)
        {
            _dbContext.Kois.Remove(koi);
        }

        // Cập nhật thông tin cá Koi
        public void Update(Koi koi)
        {
            _dbContext.Kois.Update(koi);
        }

        // Lưu các thay đổi vào cơ sở dữ liệu
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        // Một phương thức khác cũng lấy cá Koi theo ID
        public async Task<Koi> GetKoiByIdAsync(int id)
        {
            var koi = await _dbContext.Kois.FindAsync(id);
            if (koi == null)
            {
                throw new Exception("Cá Koi không tồn tại!"); // Hoặc ném một ngoại lệ nếu không tìm thấy
            }
            return koi;
        }

    }
}
