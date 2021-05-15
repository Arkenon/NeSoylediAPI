using Microsoft.EntityFrameworkCore;
using NeSoyledi.Business.Abstract;
using NeSoyledi.Data;
using NeSoyledi.Data.Abstract;
using NeSoyledi.Data.Helpers;
using NeSoyledi.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace NeSoyledi.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserRepository _userRepository;
        private readonly NeSoylediDbContext _context;
        public UserManager(IUserRepository userRepository, NeSoylediDbContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }
        public PagedList<User> GetAll(int pageNumber, int pageSize)
        {
            return PagedList<User>.ToPagedList(_userRepository.GetAll(pageNumber, pageSize), pageNumber, pageSize);
        }
        public async Task<User> GetById(int id)
        {
            return await _userRepository.GetById(id);
        }

        public bool UpdateUserToken(User user)
        {
            var _user = new User() { Id = user.Id, RefreshToken = user.RefreshToken, RefreshTokenEndDate = user.RefreshTokenEndDate };
            _context.Users.Attach(_user);
            _context.Entry(_user).Property(x => x.RefreshToken).IsModified = true;
            _context.Entry(_user).Property(x => x.RefreshTokenEndDate).IsModified = true;
            var update = _context.SaveChanges();
            bool response;
            if (update > 0)
            {
                response = true;
            }
            else
            {
                response = false;
            }
            return response;
        }

        public async Task Create(User entity)
        {
            await _userRepository.Create(entity);
        }
        public async Task Delete(int id)
        {
            await _userRepository.Delete(id);
        }
        public async Task Update(int id, User entity)
        {
            await _userRepository.Update(id, entity);
        }
        public IQueryable<User> Where(Expression<Func<User, bool>> where)
        {
            return _userRepository.Where(where);
        }

    }
}
