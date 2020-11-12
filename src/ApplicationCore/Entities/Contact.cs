using ApplicationCore.Events;
using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Linq;
using static ApplicationCore.Events.ContactEvents;

namespace ApplicationCore.Entities
{
    public class Contact : BaseEntity
    {
        private readonly List<IDomainEvent> _events;
        public IEnumerable<IDomainEvent> GetChanges() => _events.AsEnumerable();

        public FullName FullName { get; private set; }
        public EmailAddress EmailAddress { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Address Address { get; private set; }

        private Contact()
        {
            _events = new List<IDomainEvent>();
        }

        public Contact(FullName fullname, EmailAddress emailAddress, PhoneNumber phoneNumber, Address address) : this()
        {
            FullName = fullname;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            Address = address;

            _events.Add(new ContactCreated
            {
                Id = Id
            });
        }

        public void UpdateFullName(FullName fullname)
        {
            if (!FullName.Equals(fullname))
            {
                FullName = fullname;
                _events.Add(new ContactFullNameUpdated
                {
                    FullName = fullname.ToString()
                });
            }
        }

        public void UpdateEmailAddress(EmailAddress emailAddress)
        {
            if (!EmailAddress.Equals(emailAddress))
            {
                EmailAddress = emailAddress;
                _events.Add(new ContactEmailAddressUpdated
                {
                    EmailAddress = emailAddress.Value
                });
            }
        }

        public void UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            if (!PhoneNumber.Equals(phoneNumber))
            {
                PhoneNumber = phoneNumber;
                _events.Add(new ContactPhoneNumberUpdated
                {
                    PhoneNumber = phoneNumber.Value
                });
            }
        }

        public void UpdateAddress(Address address)
        {
            if (!Address.Equals(address))
            {
                Address = address;
                _events.Add(new ContactAddressUpdated
                {
                    Address = address.ToString()
                });
            }
        }

        public void Delete()
        {
            if (Id != default)
            {
                _events.Add(new ContactDeleted
                {
                    Id = Id
                });
            }
        }
    }
}
