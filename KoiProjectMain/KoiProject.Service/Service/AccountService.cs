using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;
using KoiProject.Service.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

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

        public Account GetAccountByEmailAndPassword(string email, string password)
        {
            return _accountRepository.GetAccountByEmailAndPassword(email, password);
        }

        public async Task<ClaimsPrincipal?> GetClaimsPrincipalAsync(string email, string password)
        {
            // Lấy thông tin người dùng từ database
            var account = await _accountRepository.GetAccountByEmailAndPasswordAsync(email, password);

            if (account != null)
            {
                // Gắn các claims
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, account.FullName), // Tên người dùng
                    new Claim(ClaimTypes.Email, account.Email),  // Email người dùng
                    new Claim("Role", account.UserRoleId == 3 ? "Admin" : "Member") // Gắn Role
                };

                // Tạo ClaimsIdentity và ClaimsPrincipal
                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                return new ClaimsPrincipal(claimsIdentity);
            }

            return null; // Trả về null nếu thông tin đăng nhập không hợp lệ
        }
        public async Task<bool> LoginAsync(string email, string password)
        {
            // Lấy thông tin người dùng từ database
            var account = await _accountRepository.GetAccountByEmailAndPasswordAsync(email, password);

            if (account != null)
            {
                // Gắn các claims
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.FullName), // Tên người dùng
                new Claim(ClaimTypes.Email, account.Email),  // Email người dùng
                new Claim("Role", account.UserRoleId == 3 ? "Admin" : "Member") // Phân biệt role
            };

                // Tạo ClaimsIdentity và ClaimsPrincipal
                var claimsIdentity = new ClaimsIdentity(claims, "Cookies");
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

                // Đăng nhập bằng Cookie    

                return true; // Đăng nhập thành công
            }

            return false; // Đăng nhập thất bại
        }
    }
}
