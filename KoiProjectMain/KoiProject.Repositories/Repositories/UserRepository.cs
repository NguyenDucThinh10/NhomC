using KoiProject.Repositories.Entities;
using KoiProject.Service.Interfaces;
using System;
using System.Linq;

public class UserRepository : IUserRepository
{
    private readonly FengShuiKoiDbContext _context;

    public UserRepository(FengShuiKoiDbContext context)
    {
        _context = context;
    }

    public User GetUserById(int userId)
    {
        return _context.Users.FirstOrDefault(u => u.UserId == userId);
    }

    public void AddUser(User user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }
}
