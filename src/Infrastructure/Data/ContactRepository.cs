using ApplicationCore.Entities;
using ApplicationCore.Interfaces;

namespace Infrastructure.Data
{
    public class ContactRepository : EfRepository<Contact>, IContactRepository
    {
        public ContactRepository(ContactContext dbContext) : base(dbContext)
        {
        }
    }
}
