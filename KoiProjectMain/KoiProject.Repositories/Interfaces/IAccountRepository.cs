using KoiProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiProject.Repositories.Interfaces
{
        public interface IAccountRepository
        {
            Task<List<Account>> GetAllAsync();
            Task<Account> GetByIdAsync(int accountId);
            Task AddAsync(Account account);
            Task UpdateAsync(Account account);
            Task DeleteAsync(int accountId);

            Task<Account?> GetAccountByEmailAndPasswordAsync(string email, string password);
            Account GetAccountByEmailAndPassword(string email, string password);
            Task<bool> DoesEmailExistAsync(string email);

		    Task<bool> ValidateAccountAsync(string email, string password);
            bool IsEmailExists(string email);
            void AddAccount(Account account);
            // Các phương thức cần thiết khác
        }

}
