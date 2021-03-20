using ApplicationCore.Entities;
using ApplicationCore.Entities.AggregatesModel;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IContactRepository : IAsyncRepository<Contact>
    {
        Task<bool> IsEmailAddressExists(string emailAddress);
    }
}
