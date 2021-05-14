using NeSoyledi.Data.Abstract;
using NeSoyledi.Entities;

namespace NeSoyledi.Data.Concrete
{
    public class CategoryRepository :GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(NeSoylediDbContext dbContext)
           : base(dbContext)
        {
        }
    }
}
