using Students.Domain.Models;
using System.Threading.Tasks;

namespace Students.Domain.Interfaces
{
    public interface IRepository<TModel> where TModel : BaseEntity
    {
        Task<int> CreateAsync(TModel model);

        Task<bool> UpdateAsync(TModel model);

        Task<TModel> GetAsync(int id);

        Task<bool> RemoveAsync(int id);

        Task<PageResponse<TModel>> GetPagedResult(int page, int pageSize);
    }
}
