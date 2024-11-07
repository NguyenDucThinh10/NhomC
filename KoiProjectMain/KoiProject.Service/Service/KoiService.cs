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

        public async Task<List<KoiSpecy>> GetKoisAsync()
        {
            return await _koiRepository.GetKoiesAsync();
        }

        public async Task<KoiSpecy?> GetKoiByIdAsync(int id)
        {
            return await _koiRepository.GetKoiByIdAsync(id);
        }

        public async Task<int> AddKoiAsync(KoiSpecy koi)
        {
            await _koiRepository.AddAsync(koi);
            await _koiRepository.SaveChangesAsync();
            return koi.KoiId;  // Giả sử KoiId là khóa chính tự động tăng
        }

        public async Task<int> UpdateKoiAsync(KoiSpecy koi)
        {
            _koiRepository.Update(koi);
            await _koiRepository.SaveChangesAsync();
            return koi.KoiId;
        }

        public async Task<bool> DeleteKoiAsync(int koiId)
        {
            var koi = await _koiRepository.GetKoiByIdAsync(koiId);
            if (koi == null)
            {
                return false;
            }

            _koiRepository.Delete(koi);
            await _koiRepository.SaveChangesAsync();
            return true;
        }
    }
}
