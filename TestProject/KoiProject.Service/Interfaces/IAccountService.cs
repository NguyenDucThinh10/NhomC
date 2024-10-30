using KoiProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiProject.Service.Interfaces
{
    public interface IAccountService
    {
        bool IsEmailExists(string email);
        void RegisterAccount(Account account);
    }

}
