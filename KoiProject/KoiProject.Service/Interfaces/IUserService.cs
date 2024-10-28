using KoiProject.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiProject.Service.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Kiểm tra xem email đã tồn tại trong hệ thống chưa.
        /// </summary>
        /// <param name="email">Email của người dùng.</param>
        /// <returns>True nếu email tồn tại, false nếu không.</returns>
        bool IsEmailExists(string email);

        /// <summary>
        /// Thêm một người dùng mới vào hệ thống.
        /// </summary>
        /// <param name="user">Đối tượng người dùng chứa thông tin đăng ký.</param>
        void RegisterUser(User user);
    }

}
