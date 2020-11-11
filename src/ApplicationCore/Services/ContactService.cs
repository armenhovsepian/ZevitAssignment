using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.ValueObject;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ContactService: IContactService
    {
        private readonly IAsyncRepository<Contact> _contactRepository;
        public ContactService(IAsyncRepository<Contact> contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task CreateContactAsync(FullName fullname, EmailAddress emailAddress, PhoneNumber phoneNumber, Address address)
        {
            var order = new Contact(fullname, emailAddress, phoneNumber, address);
            await _contactRepository.AddAsync(order);
        }
    }
}
