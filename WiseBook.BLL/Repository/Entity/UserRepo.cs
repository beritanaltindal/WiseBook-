using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WiseBook.DAL.ORM.Entity;

namespace WiseBook.BLL.Repository.Entity
{
    public class UserRepo : Base.BaseRepository<User>
    {
        public bool CheckCredentials(string email, string password)
        {
            return dbset.Any(x => x.Email == email && x.Password == password);
        }

        public User FindByEmail(string email)
        {
            return dbset.FirstOrDefault(x => x.Email == email);
        }

        public bool ExistingUser(string email)
        {
            return dbset.Any(x => x.Email == email);
        }

        public string[] GetRolesForUser(int Id)
        {
            var role = dbset.FirstOrDefault(x => x.Id == Id).Role;

            return new string[] { role };
        }
    }
}
