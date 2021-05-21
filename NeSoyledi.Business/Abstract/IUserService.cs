using NeSoyledi.Entities;

namespace NeSoyledi.Business.Abstract
{
    public interface IUserService : IBusinessService<User>
    {
        public bool UpdateUserToken(User user);
        public User GetUserDetail(int id);
    }
}
