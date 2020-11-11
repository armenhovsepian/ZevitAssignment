using ApplicationCore.Entities;

namespace ApplicationCore.Specifications
{
    public class ContactFilterSpecification : BaseSpecification<Contact>
    {
        public ContactFilterSpecification(int skip, int take)
            : base()
        {
            ApplyPaging(skip, take);
        }
    }
}
