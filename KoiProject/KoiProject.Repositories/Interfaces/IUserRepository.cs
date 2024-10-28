using KoiProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiProject.Repositories.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Lấy người dùng theo email.
        /// </summary>
        /// <param name="email">Email của người dùng.</param>
        /// <returns>Đối tượng User nếu tìm thấy, null nếu không.</returns>
        User GetByEmail(string email);

        /// <summary>
        /// Thêm một người dùng mới vào cơ sở dữ liệu.
        /// </summary>
        /// <param name="user">Đối tượng User cần thêm.</param>
        void Add(User user);
    }

}
