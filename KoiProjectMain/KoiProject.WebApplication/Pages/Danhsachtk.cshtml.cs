using KoiProject.Repositories.Entities;
using KoiProject.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiProject.WebApplication.Pages
{
    public class DanhsachtkModel : PageModel
    {
        private readonly IAccountService _accountService;

        public DanhsachtkModel(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public List<Account> Accounts { get; set; }

        public async Task OnGetAsync()
        {
            Accounts = await _accountService.GetAllAccountsAsync();
        }
    }
}
