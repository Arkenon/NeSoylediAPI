using System;
using System.Collections.Generic;
using System.Linq;

namespace NeSoyledi.Data.Helpers
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalPages { get; private set; }
        public int PageSize { get; private set; }
        public int TotalCount { get; private set; }
        public bool HasPrevious => CurrentPage > 1;
        public bool HasNext => CurrentPage < TotalPages;

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            if (TotalCount > 0)
            {
                AddRange(items);
            }
        }

        public static PagedList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count();
            List<T> items;
            if (count > 0)
            {
                items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            }
            else
            {
                items = null;
            }

            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}
