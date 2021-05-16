using Domain.Entities.AggregatesModel;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IContactRepository : IAsyncRepository<Contact>
    {
        Task<bool> IsEmailAddressExists(string emailAddress);
    }
}
