using Domain.Events;
using Domain.Exceptions;
using Domain.Interfaces;
using Domain.Services;
using System.Collections.Generic;
using static Domain.Events.ContactEvents;

namespace Domain.Entities.AggregatesModel
{
    public class Contact : BaseEntity, IAggregateRoot
    {
        public List<IDomainEvent> RecordedEvents { get; private set; }

        public FullName FullName { get; private set; }
        public EmailAddress EmailAddress { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Address Address { get; private set; }
        public DateOfBirth DateOfBirth { get; set; }

        public virtual List<ContactTeam> ContactTeams { get; set; }

        private Contact()
        {
            RecordedEvents = new List<IDomainEvent>();
        }

        public Contact(FullName fullname, EmailAddress emailAddress, PhoneNumber phoneNumber, Address address, DateOfBirth dateOfBirth) : this()
        {
            if (fullname == null)
                throw new ContactException("Fullname cannot be null");

            if (emailAddress == null)
                throw new ContactException("Emil address cannot be null");

            if (phoneNumber == null)
                throw new ContactException("Phone number cannot be null");

            if (dateOfBirth == null)
                throw new ContactException("Date of birth cannot be null");

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

        public void UpdateBirthOfDate(DateOfBirth dateOfBirth)
        {
            if (!DateOfBirth.Equals(dateOfBirth))
            {
                DateOfBirth = dateOfBirth;
                //RecordedEvents.Add(new ContactDateOfBirthUpdated(dateOfBirth.Value));
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


        public void AddToTeam(int teamId, TinderTeamPolicy tinderTeamPolicy)
        {
            tinderTeamPolicy.Apply();
            ContactTeams.Add(new ContactTeam(this.Id, teamId));
        }
    }
}
