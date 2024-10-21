using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiProject.Repositories.Entities;
namespace KoiProject.Repositories.Interfaces
{
    public interface IKoiRepository
    {
        Task<Koi> GetKoiByIdAsync(int id);
        Task<List<Koi>> GetKois();
        void Add(Koi koi); // Thêm cá Koi
        void Remove(Koi koi); // Xóa cá Koi
        void Update(Koi koi); // Cập nhật thông tin cá Koi
        Task<int> SaveChangesAsync(); // Lưu các thay đổi vào cơ sở dữ liệu
    }
}
