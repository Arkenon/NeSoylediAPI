using NeSoyledi.Data.Abstract;
using NeSoyledi.Entities;

namespace NeSoyledi.Data.Concrete
{
    public class DiscourseRepository : GenericRepository<Discourse>, IDiscourseRepository
    {
        public DiscourseRepository(NeSoylediDbContext dbContext) : base(dbContext)
        {

        }
    }
}
