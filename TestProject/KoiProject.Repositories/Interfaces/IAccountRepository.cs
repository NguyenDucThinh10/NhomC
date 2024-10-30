using KoiProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiProject.Repositories.Interfaces
{
    namespace KoiProject.Repositories.Interfaces
    {
        public interface IAccountRepository
        {
            bool IsEmailExists(string email);
            void AddAccount(Account account);
            // Các phương thức cần thiết khác
        }
    }

}
