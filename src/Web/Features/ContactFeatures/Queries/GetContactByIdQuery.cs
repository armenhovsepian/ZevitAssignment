using ApplicationCore.Dtos;
using ApplicationCore.Interfaces;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Features.ContactFeatures.Queries
{
    public class GetContactByIdQuery : IRequest<ContactDto>
    {
        public int Id { get; }

        public GetContactByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, ContactDto>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;
        public GetContactByIdQueryHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<ContactDto> Handle(GetContactByIdQuery request, CancellationToken ct)
        {
            var contact = await _contactRepository.GetByIdAsync(request.Id, ct);

            if (contact == null)
                return default;

            return _mapper.Map<ContactDto>(contact);
        }
    }
}
