using EF.Core.Repository.Interface.Manager;
using FirstApiRepPertten.Models;

namespace FirstApiRepPertten.Interface.Manager
{
    public interface IUserManager:ICommonManager<User>
    {
        User GetById(int id);
        ICollection<User> SarchAddress(string address);
        ICollection<User> Sarch(string text);
        ICollection<User>Pagging(int page, int pageSize);


    }
}
