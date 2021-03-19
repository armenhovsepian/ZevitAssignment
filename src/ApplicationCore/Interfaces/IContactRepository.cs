using ApplicationCore.Entities.AggregatesModel;

namespace ApplicationCore.Interfaces
{
    public interface IContactRepository : IAsyncRepository<Contact>
    {
    }
}
