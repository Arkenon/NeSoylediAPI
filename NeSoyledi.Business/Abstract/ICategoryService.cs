using NeSoyledi.Entities;
using System.Threading.Tasks;

namespace NeSoyledi.Business.Abstract
{
    public interface ICategoryService : IBusinessService<Category>
    {
        Task<Category> GetWithDiscourses(int id);
        Task<Category> GetWithVersus(int id);
       
    }
}
