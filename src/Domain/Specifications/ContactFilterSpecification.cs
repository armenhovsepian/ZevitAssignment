using Domain.Entities.AggregatesModel;

namespace Domain.Specifications
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
