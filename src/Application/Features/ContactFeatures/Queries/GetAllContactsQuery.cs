using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces;
using Domain.Specifications;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ContactFeatures.Queries
{
    public class GetAllContactsQuery : IRequest<IEnumerable<ContactDto>>
    {
        public int Skip { get; private set; }
        public int Take { get; private set; }

        public GetAllContactsQuery(int skip, int take)
        {
            Skip = skip;
            Take = take;
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
            var specification = new ContactFilterSpecification(request.Skip, request.Take);
            var contactList = await _unitOfWork.ContactRepository.ListAsync(specification, ct);

            if (contactList == null)
            {
                return null;
            }

            return contactList.Select(c => _mapper.Map<ContactDto>(c));
        }
    }
}
