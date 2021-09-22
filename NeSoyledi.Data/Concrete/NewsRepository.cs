using NeSoyledi.Data.Abstract;
using NeSoyledi.Entities;

namespace NeSoyledi.Data.Concrete
{
    public class NewsRepository : GenericRepository<News>, INewsRepository
    {
        public NewsRepository(NeSoylediDbContext dbContext)
          : base(dbContext)
        {
        }
    }
}
