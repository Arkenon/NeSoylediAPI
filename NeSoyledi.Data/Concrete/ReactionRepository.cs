using NeSoyledi.Data.Abstract;
using NeSoyledi.Entities;

namespace NeSoyledi.Data.Concrete
{
    public class ReactionRepository : GenericRepository<Reaction>, IReactionRepository
    {
        public ReactionRepository(NeSoylediDbContext dbContext)
         : base(dbContext)
        {
        }
    }
}
