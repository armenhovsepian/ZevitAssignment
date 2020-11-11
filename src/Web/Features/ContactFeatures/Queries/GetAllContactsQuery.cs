using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Features.ContactFeatures.Queries
{
    public class GetAllContactsQuery: IRequest<IEnumerable<Contact>>
    {
        public PagingOptions PagingOptions { get; set; }
        public GetAllContactsQuery(PagingOptions pagingOptions)
        {
            PagingOptions = pagingOptions;
        }
    }

    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<Contact>>
    {
        private readonly IContactRepository _contactRepository;

        public GetAllContactsQueryHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<Contact>> Handle(GetAllContactsQuery request, CancellationToken cancellationToken)
        {
            var specification = new ContactFilterSpecification(request.PagingOptions.Skip, request.PagingOptions.Take);
            var contactList = await _contactRepository.ListAsync(specification);

            if (contactList == null)
            {
                return null;
            }
            return contactList;
        }
    }
}
