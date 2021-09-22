using NeSoyledi.Business.Abstract;
using NeSoyledi.Data.Abstract;
using NeSoyledi.Data.Helpers;
using NeSoyledi.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NeSoyledi.Business.Concrete
{
    class NewsManager : INewsService
    {
        private INewsRepository _newsRepository;
        public NewsManager(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }
        public PagedList<News> GetAll(int pageNumber, int pageSize)
        {
            return PagedList<News>.ToPagedList(_newsRepository.GetAll(pageNumber, pageSize), pageNumber, pageSize);
        }
        public async Task<News> GetById(int id)
        {
            return await _newsRepository.GetById(id);
        }
        public IQueryable<News> Where(Expression<Func<News, bool>> where)
        {
            return _newsRepository.Where(where);
        }
        public int Create(News entity)
        {
            return _newsRepository.Create(entity);
        }
        public void Update(int id, News entity)
        {
            _newsRepository.Update(id, entity);
        }
        public async Task Delete(int id)
        {
            await _newsRepository.Delete(id);
        }
    }
}
