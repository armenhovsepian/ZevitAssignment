using Domain.Entities.AggregatesModel;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class ContactRepository : EfRepository<Contact>, IContactRepository
    {
        public ContactRepository(ContactContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsEmailAddressExists(string emailAddress)
        {
            return await _dbContext.Contacts
                .AnyAsync(c => c.EmailAddress.Value.Equals(emailAddress, System.StringComparison.OrdinalIgnoreCase));
        }
    }
}
