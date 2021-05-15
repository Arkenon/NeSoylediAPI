using NeSoyledi.Entities;
using System.Threading.Tasks;

namespace NeSoyledi.Business.Abstract
{
    public interface IUserService : IBusinessService<User>
    {
        public bool UpdateUserToken(User user);
    }
}
