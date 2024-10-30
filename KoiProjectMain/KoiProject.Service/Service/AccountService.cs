using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using KoiProject.Service.Interfaces;

namespace KoiProject.Service
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public bool IsEmailExists(string email)
        {
            return _accountRepository.IsEmailExists(email);
        }

        public void RegisterAccount(Account account)
        {
            _accountRepository.AddAccount(account);
        }
    }
}
