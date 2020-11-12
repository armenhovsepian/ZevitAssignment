using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using NUnit.Framework;

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
    }
}
