using NeSoyledi.Data.Helpers;
using NeSoyledi.Entities;

namespace NeSoyledi.Business.Abstract
{
    public interface IProfileService : IBusinessService<Profiles>
    {
        PagedList<Profiles> GetProfilesForHome(int pageNumber, int pageSize);
    }
}
