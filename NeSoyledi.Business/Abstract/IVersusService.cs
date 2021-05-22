using NeSoyledi.Entities;
using System.Linq;

namespace NeSoyledi.Business.Abstract
{
    public interface IVersusService : IBusinessService<Versus>
    {
        IQueryable<Versus> GetVersusForHome(int pageNumber, int pageSize);
    }
}
