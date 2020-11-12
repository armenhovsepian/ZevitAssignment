using ApplicationCore.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;

namespace IntegrationTests.Repositories
{
    public class ContactRepositoryTests
    {
        private ContactContext _contactContext;
        private ContactRepository _contactRepository;

        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<ContactContext>()
                .UseInMemoryDatabase(databaseName: "TestZevitDb")
                .Options;
            _contactContext = new ContactContext(dbOptions);
            _contactRepository = new ContactRepository(_contactContext);
        }

        [Test]
        public async Task CreateContact()
        {
            var contact = new Contact(
                new FullName("Armen", "Hovsepian"),
                new EmailAddress("rmn.hovsepian@live.com"),
                new PhoneNumber("+374-94331230"),
                new Address("Tigran Petrosyan","Yerevan","Davtashen","Armenia", "1234")
                );

            await _contactRepository.AddAsync(contact, CancellationToken.None);

            Assert.AreNotEqual(contact.Id, 0);
        }
    }
}
