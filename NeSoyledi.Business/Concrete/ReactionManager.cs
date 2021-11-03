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
    public class ReactionManager : IReactionService
    {
        private IReactionRepository _reactionRepository;
        public ReactionManager(IReactionRepository reactionRepository)
        {
            _reactionRepository = reactionRepository;
        }
        public PagedList<Reaction> GetAll(int pageNumber, int pageSize)
        {
            return PagedList<Reaction>.ToPagedList(_reactionRepository.GetAll(pageNumber, pageSize), pageNumber, pageSize);
        }
        public async Task<Reaction> GetById(int id)
        {
            return await _reactionRepository.GetById(id);
        }
        public IQueryable<Reaction> Where(Expression<Func<Reaction, bool>> where)
        {
            return _reactionRepository.Where(where);
        }
        public int Create(Reaction entity)
        {
            return _reactionRepository.Create(entity);
        }
        public void Update(int id, Reaction entity)
        {
            _reactionRepository.Update(id, entity);
        }
        public async Task Delete(int id)
        {
            await _reactionRepository.Delete(id);
        }
    }
}
