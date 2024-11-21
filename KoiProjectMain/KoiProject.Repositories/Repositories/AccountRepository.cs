using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
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

        public async Task<Account?> GetAccountByEmailAndPasswordAsync(string email, string password)
        {
            using var connection = new SqlConnection("Data Source=DESKTOP-QFUFB46;Initial Catalog=FengShuiKoiDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
            await connection.OpenAsync();

            var query = @"SELECT AccountId, FullName, Email, Password, UserRoleId
                      FROM Accounts
                      WHERE Email = @Email AND Password = @Password";

            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@Email", email);
            command.Parameters.AddWithValue("@Password", password);

            using var reader = await command.ExecuteReaderAsync();
            if (await reader.ReadAsync())
            {
                return new Account
                {
                    AccountId = reader.GetInt32(0),
                    FullName = reader.GetString(1),
                    Email = reader.GetString(2),
                    Password = reader.GetString(3),
                    UserRoleId = reader.GetInt32(4)
                };
            }

            return null;
        }

        public async Task<List<Account>> GetAllAsync()
        {
            return await _context.Accounts.ToListAsync();
        }

        public async Task<Account> GetByIdAsync(int accountId)
        {
            return await _context.Accounts.FindAsync(accountId);
        }

        public async Task AddAsync(Account account)
        {
            await _context.Accounts.AddAsync(account);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Account account)
        {
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int accountId)
        {
            var account = await GetByIdAsync(accountId);
            if (account != null)
            {
                _context.Accounts.Remove(account);
                await _context.SaveChangesAsync();
            }
        }
    }
}
