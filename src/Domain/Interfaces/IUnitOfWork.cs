using System;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/aspnet/mvc/overview/older-versions/getting-started-with-ef-5-using-mvc-4/implementing-the-repository-and-unit-of-work-patterns-in-an-asp-net-mvc-application
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        IContactRepository ContactRepository { get; }
        ITeamRepository TeamRepository { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
