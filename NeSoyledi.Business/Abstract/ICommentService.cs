using NeSoyledi.Data.Helpers;
using NeSoyledi.Entities;

namespace NeSoyledi.Business.Abstract
{
    public interface ICommentService : IBusinessService<Comment>
    {
        PagedList<Comment> GetCommentsByUserId(int pageNumber, int pageSize, int userId);
    }
}
