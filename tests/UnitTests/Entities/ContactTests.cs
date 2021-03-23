using Domain.Entities;
using Domain.Entities.AggregatesModel;
using Domain.Exceptions;
using NUnit.Framework;
using System.Linq;
using static Domain.Events.ContactEvents;

namespace UnitTests.Entities
{
    [Category("UnitTests")]
    public class ContactTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void EmailAddressCanNotBeEmpty()
        {
            var ex = Assert.Throws<ContactException>(() => new EmailAddress(string.Empty));
            Assert.That(ex.Message, Is.EqualTo("Invalid e-mail address"));
        }

        [Test]
        public void FullNameCanNotBeEmpty()
        {
            var ex = Assert.Throws<ContactException>(() => new FullName(string.Empty, ""));
            Assert.That(ex.Message, Is.EqualTo("FirstName can not be null or empty"));
        }

        [Test]
        public void EventWilleRecorded()
        {
            var contact = new Contact(
                new FullName("Armen", "Hovsepian"),
                new EmailAddress("rmn.hovsepian@live.com"),
                new PhoneNumber("+374-94331230"),
                new Address("Tigran Petrosyan", "Yerevan", "Davtashen", "Armenia", "1234")
                );

            var wasRecorded = contact
                    .RecordedEvents
                    .OfType<ContactCreated>()
                    .Count() == 1;

            Assert.IsTrue(wasRecorded);
        }

    }
}
