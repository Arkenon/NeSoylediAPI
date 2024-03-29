﻿using NeSoyledi.Data.Helpers;
using NeSoyledi.Entities;
using System.Linq;

namespace NeSoyledi.Business.Abstract
{
    public interface IDiscourseService : IBusinessService<Discourse>
    {
        IQueryable<Discourse> GetDiscoursesForHome(int pageNumber, int pageSize);
        PagedList<Discourse> GetDiscoursesByProfileId(int pageNumber, int pageSize, int profileId, string order, string starDate = "", string endDate = "");
        PagedList<Discourse> GetDiscoursesByUserId(int pageNumber, int pageSize, int userId);
        PagedList<Discourse> GetDiscoursesByCategoryId(int pageNumber, int pageSize, int categoryId);
    }
}
