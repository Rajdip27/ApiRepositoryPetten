using EF.Core.Repository.Repository;
using FirstApiRepPertten.Interface.Repository;
using FirstApiRepPertten.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApiRepPertten.Repository
{
    public class UserRepository : CommonRepository<User>, IUserRepository
    {
        public UserRepository(DbContext DbContext) : base(DbContext)
        {
        }
    }
}
