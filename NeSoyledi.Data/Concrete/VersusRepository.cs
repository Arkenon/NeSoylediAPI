using NeSoyledi.Data.Abstract;
using NeSoyledi.Entities;

namespace NeSoyledi.Data.Concrete
{
    public class VersusRepository : GenericRepository<Versus>, IVersusRepository
    {
        public VersusRepository(NeSoylediDbContext dbContext) : base(dbContext)
        {
        }
    }
}
