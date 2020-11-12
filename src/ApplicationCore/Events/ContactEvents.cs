using System;

namespace ApplicationCore.Events
{
    public static class ContactEvents
    {
        public class BaseContactEvent : IDomainEvent
        {
            public int Id { get; set; }

            public DateTimeOffset Created { get; set; } = DateTimeOffset.UtcNow;
        }

        public class ContactCreated : BaseContactEvent
        {
            // store created userId
        }

        public class ContactDeleted : BaseContactEvent
        {
            // store deleted userId
        }

        public class ContactFullNameUpdated : BaseContactEvent
        {
            public string FullName { get; set; }
        }

        public class ContactEmailAddressUpdated : BaseContactEvent
        {
            public string EmailAddress { get; set; }
        }

        public class ContactAddressUpdated : BaseContactEvent
        {
            public string Address { get; set; }
        }

        public class ContactPhoneNumberUpdated : BaseContactEvent
        {
            public string PhoneNumber { get; set; }
        }
    }
}
