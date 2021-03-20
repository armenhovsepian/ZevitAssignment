using ApplicationCore.Events;
using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using System.Collections.Generic;
using static ApplicationCore.Events.ContactEvents;

namespace ApplicationCore.Entities.AggregatesModel
{
    public class Contact : BaseEntity, IAggregateRoot
    {
        public List<IDomainEvent> RecordedEvents { get; private set; }

        public FullName FullName { get; private set; }
        public EmailAddress EmailAddress { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Address Address { get; private set; }

        private Contact()
        {
            RecordedEvents = new List<IDomainEvent>();
        }

        public Contact(FullName fullname, EmailAddress emailAddress, PhoneNumber phoneNumber, Address address) : this()
        {
            if (fullname == null)
                throw new ContactException("Fullname cannot be null");

            if (emailAddress == null)
                throw new ContactException("Emil address cannot be null");

            if (phoneNumber == null)
                throw new ContactException("Phone number cannot be null");

            FullName = fullname;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            Address = address;

            RecordedEvents.Add(new ContactCreated(Id));
        }

        public void UpdateFullName(FullName fullname)
        {
            if (!FullName.Equals(fullname))
            {
                FullName = fullname;
                RecordedEvents.Add(new ContactFullNameUpdated(fullname.ToString()));
            }
        }

        public void UpdateEmailAddress(EmailAddress emailAddress)
        {
            if (!EmailAddress.Equals(emailAddress))
            {
                EmailAddress = emailAddress;
                RecordedEvents.Add(new ContactEmailAddressUpdated(emailAddress.Value));
            }
        }

        public void UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            if (!PhoneNumber.Equals(phoneNumber))
            {
                PhoneNumber = phoneNumber;
                RecordedEvents.Add(new ContactPhoneNumberUpdated(phoneNumber.Value));
            }
        }

        public void UpdateAddress(Address address)
        {
            if (!Address.Equals(address))
            {
                Address = address;
                RecordedEvents.Add(new ContactAddressUpdated(address.ToString()));
            }
        }

        public void Delete()
        {
            if (Id != default(int))
            {
                RecordedEvents.Add(new ContactDeleted(Id));
            }
        }
    }
}
