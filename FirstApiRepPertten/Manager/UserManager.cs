using EF.Core.Repository.Manager;
using EF.Core.Repository.Repository;
using FirstApiRepPertten.ApplicationDbCon;
using FirstApiRepPertten.Interface.Manager;
using FirstApiRepPertten.Models;
using FirstApiRepPertten.Repository;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace FirstApiRepPertten.Manager
{
    public class UserManager : CommonManager<User>, IUserManager
    {
        public UserManager(ApplicationDbContext db):base(new UserRepository(db))
        {

        }

        public User GetById(int id)
        {
           return GetFirstOrDefault(x=>x.Id==id);
        }

        public ICollection<User> Pagging(int page, int pageSize)
        {
            if (page <= 1)
            {
                page = 0;
            }
            int total=page*pageSize;
            return GetAll().Skip(total).Take(pageSize).ToList();
        }

        public ICollection<User> Sarch(string text)
        {
            return Get(x => x.Address.ToLower().Contains(text) || x.Name.ToLower().Contains(text)||x.Email.ToLower().Contains(text));

        }

        public ICollection<User> SarchAddress(string address)
        {
            return Get(x => x.Address.ToLower().Contains(address));
        }
    }
}
