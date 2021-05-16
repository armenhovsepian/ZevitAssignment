using System;

namespace Domain.Events
{
    public static class ContactEvents
    {
        public class BaseContactEvent : IDomainEvent
        {
            public int Id { get; protected set; }

            public DateTimeOffset Created { get; protected set; } = DateTimeOffset.UtcNow;
        }

        public class ContactCreated : BaseContactEvent
        {
            public ContactCreated(int id) => Id = id;
            // store created userId
        }

        public class ContactDeleted : BaseContactEvent
        {
            public ContactDeleted(int id) => Id = id;
            // store deleted userId
        }

        public class ContactFullNameUpdated : BaseContactEvent
        {
            public ContactFullNameUpdated(string fullName) => FullName = fullName;
            public string FullName { get; private set; }
        }

        public class ContactEmailAddressUpdated : BaseContactEvent
        {
            public ContactEmailAddressUpdated(string emailAddress) => EmailAddress = emailAddress;
            public string EmailAddress { get; private set; }
        }

        public class ContactAddressUpdated : BaseContactEvent
        {
            public ContactAddressUpdated(string address) => Address = address;
            
            public string Address { get; private set; }
        }

        public class ContactPhoneNumberUpdated : BaseContactEvent
        {
            public ContactPhoneNumberUpdated(string phoneNumber) => PhoneNumber = phoneNumber;
            public string PhoneNumber { get; private set; }
        }
    }
}
