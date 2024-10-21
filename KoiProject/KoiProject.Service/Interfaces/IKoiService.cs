using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiProject.Repositories.Entities;
namespace KoiProject.Service.Interfaces
{
    public interface IKoiService
    {
        Task<List<Koi>> getKoiAsync();
        Task<int> AddKoiAsync(Koi koi);
        Task <bool>DeleteKoiAsync(int KoiId);
        Task<int> RemoveKoiAsync(int KoiId);
        Task<int> UpdateKoi(Koi koi);
        Task<Koi> GetKoiByIdAsync(int id);
    }
}
