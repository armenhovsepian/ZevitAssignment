using Domain.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// Repository Pattern Goals
    /// ● Decouple Business code from data Access.As a result, the persistence Framework can be changed without a great effort
    /// ● Separation of Concerns
    /// ● Minimize duplicate query logic
    /// ● Testability
    /// </summary>
    /// <typeparam name="T"></typeparam>
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
