using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id, CancellationToken ct);
        Task<IReadOnlyList<T>> ListAllAsync(CancellationToken ct);
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec, CancellationToken ct);
        Task<T> AddAsync(T entity, CancellationToken ct);
        Task UpdateAsync(T entity, CancellationToken ct);
        Task DeleteAsync(T entity, CancellationToken ct);
    }
}
