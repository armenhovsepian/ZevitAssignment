using ApplicationCore.Entities;
using NUnit.Framework;

namespace UnitTests.Entities
{
    public class FullNameTests
    {
        [Test]
        public void CreateFullName()
        {
            var fullName = new FullName("Armen","Hovsepian");
            Assert.AreEqual("Armen Hovsepian", fullName.ToString());
        }

    }
}
