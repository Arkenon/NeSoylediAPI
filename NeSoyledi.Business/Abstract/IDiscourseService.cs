using NeSoyledi.Entities;
using System.Linq;

namespace NeSoyledi.Business.Abstract
{
    public interface IDiscourseService: IBusinessService<Discourse>
    {
        IQueryable<Discourse> GetAllWithLazyPaged(int page, int pageSize);
    }
}
