using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiProject.Repositories.Entities; // Thêm đúng namespace

namespace KoiProject.Repositories.Interfaces
{
    public interface IKoiRepository
    {
        Task<List<KoiSpecy>> GetKoiSpeciesByElementAsync(string element);
        Task<List<KoiSpecy>> GetKoiesAsync();  // Lấy danh sách tất cả cá Koi
        Task<KoiSpecy> GetKoiByIdAsync(int id);  // Lấy cá Koi theo ID
        Task AddAsync(KoiSpecy koi);  // Thêm mới cá Koi
        void Delete(KoiSpecy koi);  // Xóa cá Koi
        void Update(KoiSpecy koi);  // Cập nhật cá Koi
        Task SaveChangesAsync();  // Lưu các thay đổi vào cơ sở dữ liệu
    }
}

