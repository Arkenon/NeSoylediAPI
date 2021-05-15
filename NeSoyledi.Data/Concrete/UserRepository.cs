using NeSoyledi.Data.Abstract;
using NeSoyledi.Entities;

namespace NeSoyledi.Data.Concrete
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(NeSoylediDbContext dbContext)
           : base(dbContext)
        {
        }
    }
}
