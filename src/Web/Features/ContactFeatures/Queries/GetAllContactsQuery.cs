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
    public class GetAllContactsQuery : IRequest<IEnumerable<ContactDto>>
    {
        public PagingOptions PagingOptions { get; private set; }

        public GetAllContactsQuery(PagingOptions pagingOptions)
        {
            PagingOptions = pagingOptions;

        }
    }

    public class GetAllContactsQueryHandler : IRequestHandler<GetAllContactsQuery, IEnumerable<ContactDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllContactsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ContactDto>> Handle(GetAllContactsQuery request, CancellationToken ct)
        {
            var specification = new ContactFilterSpecification(request.PagingOptions.Skip, request.PagingOptions.Take);
            var contactList = await _unitOfWork.ContactRepository.ListAsync(specification, ct);

            if (contactList == null)
            {
                return null;
            }

            return contactList.Select(c => _mapper.Map<ContactDto>(c));
        }
    }
}
