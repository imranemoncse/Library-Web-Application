using LibraryManagementSystem.DAL.Repository;
using LibraryManagementSystem.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.BLL.Manager
{
    public class UserManager
    {
        UserRepository _userRepository = new UserRepository();
        public bool AuthUser(User user)
        {
          
            return _userRepository.AuthUser(user);
        }
        public bool AddUser(User user)
        {

            return _userRepository.AddUser(user);
        }
    }

   
}
