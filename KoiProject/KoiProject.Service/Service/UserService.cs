using KoiProject.Repositories.Entities;
using KoiProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiProject.Repositories.Entities;
using KoiProject.Repositories.Interfaces;

namespace KoiProject.Service.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsEmailExists(string email)
        {
            return _userRepository.GetByEmail(email) != null;
        }

        public void RegisterUser(User user)
        {
            if (!IsEmailExists(user.Email))
            {
                _userRepository.Add(user);
            }
            else
            {
                throw new Exception("Email đã tồn tại trong hệ thống.");
            }
        }
    }

}
