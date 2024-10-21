using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using KoiProject.Service.Interfaces;
namespace KoiProject.Service.Services
{
    public class KoiService: IKoiService
    {
        private readonly IKoiRepository _koiRepository;
        public KoiService(IKoiRepository koiRepository)
        {
            _koiRepository = koiRepository;
        }
        public  Task<int> AddKoiAsync(Koi koi)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteKoiAsync(int KoiId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Koi>> GetKoiAsync()
        {
            return await _koiRepository.GetKois();
        }

        public Task<List<Koi>> getKoiAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> RemoveKoiAsync(int KoiId)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateKoi(Koi koi)
        {
            throw new NotImplementedException();
        }
        public async Task<Koi> GetKoiByIdAsync(int id)
        {
            return await _koiRepository.GetKoiByIdAsync(id);
        }
    }
}
