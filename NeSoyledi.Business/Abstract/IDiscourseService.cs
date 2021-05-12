using NeSoyledi.Entities;
using System.Linq;

namespace NeSoyledi.Business.Abstract
{
    public interface IDiscourseService: IBusinessService<Discourse>
    {
        IQueryable<Discourse> GetAllWithLazyPaged(int page, int pageSize);
        IQueryable<Discourse> GetDiscoursesForHome();
        IQueryable<Discourse> GetDiscoursesByProfileId(int profileId, string order);
    }
}
