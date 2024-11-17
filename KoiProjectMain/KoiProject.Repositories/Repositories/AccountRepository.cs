using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KoiProject.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly FengShuiKoiDbContext _context;

        public AccountRepository(FengShuiKoiDbContext context)
        {
            _context = context;
        }

        // Kiểm tra email có tồn tại trong database hay không
        public bool IsEmailExists(string email)
        {
            return _context.Accounts.Any(a => a.Email == email);
        }

        // Thêm tài khoản mới vào database
        public void AddAccount(Account account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

		public async Task<bool> DoesEmailExistAsync(string email)
		{
			return await _context.Accounts.AnyAsync(a => a.Email == email);
		}


		public async Task<bool> ValidateAccountAsync(string email, string password)
		{
			return await _context.Accounts
				.AnyAsync(a => a.Email == email && a.Password == password);
		}
        public Account GetAccountByEmailAndPassword(string email, string password)
        {
            return _context.Accounts.FirstOrDefault(a => a.Email == email && a.Password == password);
        }
    }
}
