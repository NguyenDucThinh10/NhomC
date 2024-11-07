using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiProject.Repositories.Interfaces;
using KoiProject.Repositories.Entities;

namespace KoiProject.Repositories.Repositories
{
    public class KoiRepository : IKoiRepository
    {
        private readonly FengShuiKoiDbContext _context;

        public KoiRepository(FengShuiKoiDbContext context)
        {
            _context = context;
        }

        public async Task<List<KoiSpecy>> GetKoiesAsync()
        {
            return await _context.KoiSpecies.ToListAsync();  // Đảm bảo _context.KoiSpecies là DbSet<KoiSpecy>
        }

        public async Task<KoiSpecy> GetKoiByIdAsync(int id)
        {
            return await _context.KoiSpecies.FindAsync(id);
        }

        public async Task AddAsync(KoiSpecy koi)
        {
            await _context.KoiSpecies.AddAsync(koi);
        }

        public void Delete(KoiSpecy koi)
        {
            _context.KoiSpecies.Remove(koi);
        }

        public void Update(KoiSpecy koi)
        {
            _context.KoiSpecies.Update(koi);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<KoiSpecy>> GetKoiSpeciesByElementAsync(string element)
        {
            return await _context.KoiSpecies
                .Where(k => k.SuitableElement == element)
                .ToListAsync();
        }
    }
}
