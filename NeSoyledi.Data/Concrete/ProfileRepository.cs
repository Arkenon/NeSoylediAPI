using NeSoyledi.Data.Abstract;
using NeSoyledi.Entities;

namespace NeSoyledi.Data.Concrete
{
    public class ProfileRepository : GenericRepository<Profiles>, IProfileRepository
    {
        public ProfileRepository(NeSoylediDbContext dbContext) : base(dbContext)
        {

        }
    }
}
