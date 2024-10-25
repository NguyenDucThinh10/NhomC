using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiProject.Repositories.Entities; // Thêm đúng namespace

namespace KoiProject.Repositories.Interfaces
{
    public interface IKoiRepository
    {
        Task<KoiFish?> GetKoiByIdAsync(int id);
        Task<List<KoiFish>> GetKoisAsync();
        void Add(KoiFish koi); // Thêm cá KoiFish
        void Remove(KoiFish koi); // Xóa cá KoiFish
        void Update(KoiFish koi); // Cập nhật thông tin cá KoiFish
        Task<int> SaveChangesAsync(); // Lưu các thay đổi vào cơ sở dữ liệu
    }
}
