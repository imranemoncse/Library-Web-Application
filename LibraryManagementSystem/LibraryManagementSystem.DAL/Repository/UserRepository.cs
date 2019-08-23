using LibraryManagementSystem.DatabaseContext.DatabaseContext;
using LibraryManagementSystem.Model.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.DAL.Repository
{
    public class UserRepository
    {
        LibraryManagementDBContext db = new LibraryManagementDBContext();

        public bool AuthUser(User user)
        {
            User getUser =  db.Users.Where(c => c.UserName == user.UserName && c.Password == user.Password).SingleOrDefault();
            if (getUser == null)
            {
                return false;
            }

            return true;
        }

        public bool AddUser(User user)
        {
            db.Users.Add(user);
            int isExecute = db.SaveChanges();
            if (isExecute> 0)
            {
                return true;
            }

            return false;
        }
    }
}
