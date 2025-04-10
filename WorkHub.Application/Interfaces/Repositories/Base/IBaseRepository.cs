using WorkHub.Domain.Entities.Base;

namespace WorkHub.Application.Interfaces.Repositories.Base;
public interface IBaseRepository<T> where T : BaseEntity
{
    Task<bool> DeleteAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(Guid id);
    Task<bool> InsertAsync(T entity);
    Task<bool> UpdateAsync(T entity);
}