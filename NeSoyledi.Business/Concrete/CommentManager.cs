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
    public class CommentManager : ICommentService
    {
        private ICommentRepository _CommentRepository;
        public CommentManager(ICommentRepository CommentRepository)
        {
            _CommentRepository = CommentRepository;
        }
        public PagedList<Comment> GetAll(int pageNumber, int pageSize)
        {
            return PagedList<Comment>.ToPagedList(_CommentRepository.GetAll(pageNumber, pageSize), pageNumber, pageSize);
        }
        public async Task<Comment> GetById(int id)
        {
            return await _CommentRepository.GetById(id);
        }
        public IQueryable<Comment> Where(Expression<Func<Comment, bool>> where)
        {
            return _CommentRepository.Where(where);
        }
        public void Create(Comment entity)
        {
            _CommentRepository.Create(entity);
        }
        public void Update(int id, Comment entity)
        {
            _CommentRepository.Update(id, entity);
        }
        public async Task Delete(int id)
        {
            await _CommentRepository.Delete(id);
        }

        public PagedList<Comment> GetCommentsByUserId(int pageNumber, int pageSize, int userId)
        {
            return PagedList<Comment>.ToPagedList(_CommentRepository.Where(x => x.UserId == userId)
                   .OrderByDescending(r => r.CommentDate), pageNumber, pageSize);
        }

    }
}
