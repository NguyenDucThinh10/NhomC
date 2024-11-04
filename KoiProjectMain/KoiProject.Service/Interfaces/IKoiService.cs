using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiProject.Repositories.Entities; // Thêm đúng namespace

namespace KoiProject.Service.Interfaces
{
    public interface IKoiService
    {
        Task<List<KoiFish>> GetKoisAsync();
        Task<int> AddKoiAsync(KoiFish koi);
        Task<bool> DeleteKoiAsync(int koiId);
        Task<int> UpdateKoiAsync(KoiFish koi);
        Task<KoiFish?> GetKoiByIdAsync(int id);
    }
}
