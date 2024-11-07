using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiProject.Repositories.Entities; // Thêm đúng namespace

namespace KoiProject.Service.Interfaces
{
    public interface IKoiService
    {
        Task<List<KoiSpecy>> GetKoisAsync();
        Task<int> AddKoiAsync(KoiSpecy koi);
        Task<bool> DeleteKoiAsync(int koiId);
        Task<int> UpdateKoiAsync(KoiSpecy koi);
        Task<KoiSpecy?> GetKoiByIdAsync(int id);
    }
}
