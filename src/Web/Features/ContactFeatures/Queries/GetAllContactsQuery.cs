using ApplicationCore.Dtos;
using ApplicationCore.Interfaces;
using ApplicationCore.Specifications;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Features.ContactFeatures.Queries
{
    public class GetAllContactsQuery: IRequest<IEnumerable<ContactDto>>
    {
        public PagingOptions PagingOptions { get; set; }
        
        public GetAllContactsQuery(PagingOptions pagingOptions)
        {
            PagingOptions = pagingOptions;

        }
    }

    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<ContactDto>>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public GetAllContactsQueryHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactDto>> Handle(GetAllContactsQuery request, CancellationToken ct)
        {
            var specification = new ContactFilterSpecification(request.PagingOptions.Skip, request.PagingOptions.Take);
            var contactList = await _contactRepository.ListAsync(specification, ct);

            if (contactList == null)
            {
                return null;
            }

            return contactList.Select(c => _mapper.Map<ContactDto>(c));
        }
    }
}
