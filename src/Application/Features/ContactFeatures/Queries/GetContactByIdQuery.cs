using AutoMapper;
using Domain.Dtos;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ContactFeatures.Queries
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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetContactByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ContactDto> Handle(GetContactByIdQuery request, CancellationToken ct)
        {
            var contact = await _unitOfWork.ContactRepository.GetByIdAsync(request.Id, ct);

            if (contact == null)
                return default;

            return _mapper.Map<ContactDto>(contact);
        }
    }
}
