using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiProject.Repositories.Entities; // Đảm bảo đúng namespace
using KoiProject.Repositories.Interfaces;
using KoiProject.Service.Interfaces;
namespace KoiProject.Service.Services
{
    public class KoiService : IKoiService
    {
        private readonly IKoiRepository _koiRepository;

        public KoiService(IKoiRepository koiRepository)
        {
            _koiRepository = koiRepository;
        }

        public async Task<int> AddKoiAsync(KoiFish koi)
        {
            _koiRepository.Add(koi);
            return await _koiRepository.SaveChangesAsync();
        }

        public async Task<bool> DeleteKoiAsync(int koiId)
        {
            var koi = await _koiRepository.GetKoiByIdAsync(koiId);
            if (koi == null)
            {
                return false;
            }

            _koiRepository.Remove(koi);
            await _koiRepository.SaveChangesAsync();
            return true;
        }

        public async Task<List<KoiFish>> GetKoisAsync()
        {
            return await _koiRepository.GetKoisAsync();
        }

        public async Task<int> UpdateKoiAsync(KoiFish koi)
        {
            _koiRepository.Update(koi);
            return await _koiRepository.SaveChangesAsync();
        }

        public async Task<KoiFish?> GetKoiByIdAsync(int id)
        {
            return await _koiRepository.GetKoiByIdAsync(id);
        }
    }
}
