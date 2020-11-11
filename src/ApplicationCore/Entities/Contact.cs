using ApplicationCore.ValueObject;

namespace ApplicationCore.Entities
{
    public class Contact : BaseEntity
    {
        public FullName FullName { get; private set; }
        public EmailAddress EmailAddress { get; private set; }
        public PhoneNumber PhoneNumber { get; private set; }
        public Address Address { get; private set; }

        private Contact()
        {
            // required by EF
        }

        public Contact(FullName fullname, EmailAddress emailAddress, PhoneNumber phoneNumber, Address address)
        {
            FullName = fullname;
            EmailAddress = emailAddress;
            PhoneNumber = phoneNumber;
            Address = address;
        }

        public void UpdateFullName(FullName fullname)
        {
            FullName = fullname;
        }

        public void UpdateEmailAddress(EmailAddress emailAddress)
        {
            EmailAddress = emailAddress;
        }

        public void UpdatePhoneNumber(PhoneNumber phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }

        public void UpdateAddress(Address address)
        {
            Address = address;
        }
    }
}
