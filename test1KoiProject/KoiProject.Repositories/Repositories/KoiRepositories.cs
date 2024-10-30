using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiProject.Repositories.Entities; // Đảm bảo đúng namespace
using KoiProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiProject.Repositories.Repositories
{
    public class KoiRepository : IKoiRepository
    {
        private readonly FengShuiKoiDbContext _dbContext;

        public KoiRepository(FengShuiKoiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<KoiFish?> GetKoiByIdAsync(int id)
        {
            return await _dbContext.KoiFishes.FindAsync(id); // Thay KoiFish bằng KoiFishes
        }

        public async Task<List<KoiFish>> GetKoisAsync()
        {
            return await _dbContext.KoiFishes.ToListAsync(); // Thay KoiFish bằng KoiFishes
        }

        public void Add(KoiFish koi)
        {
            _dbContext.KoiFishes.Add(koi); // Thay KoiFish bằng KoiFishes
        }

        public void Remove(KoiFish koi)
        {
            _dbContext.KoiFishes.Remove(koi); // Thay KoiFish bằng KoiFishes
        }

        public void Update(KoiFish koi)
        {
            _dbContext.KoiFishes.Update(koi); // Thay KoiFish bằng KoiFishes
        }
        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }


    }
}
