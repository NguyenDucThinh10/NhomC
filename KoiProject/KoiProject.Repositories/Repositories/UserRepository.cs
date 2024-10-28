using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiProject.Repositories.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly FengShuiKoiDbContext _context;

        public UserRepository(FengShuiKoiDbContext context)
        {
            _context = context;
        }

        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
    }


}
