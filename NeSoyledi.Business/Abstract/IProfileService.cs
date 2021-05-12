using NeSoyledi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeSoyledi.Business.Abstract
{
    public interface IProfileService : IBusinessService<Profiles>
    {
        IQueryable<Profiles> GetAllWithLazyPaged(int page, int pageSize);
        IQueryable<Profiles> GetProfilesForHome();
    }
}
