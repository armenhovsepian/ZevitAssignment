using ApplicationCore.ValueObject;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IContactService
    {
        Task CreateContactAsync(FullName fullname, EmailAddress emailAddress, PhoneNumber phoneNumber, Address address);
    }
}
