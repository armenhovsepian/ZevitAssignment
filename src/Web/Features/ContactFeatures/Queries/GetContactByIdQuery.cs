using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Features.ContactFeatures.Queries
{
    public class GetContactByIdQuery : IRequest<Contact>
    {
        public int Id { get; }

        public GetContactByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetContactByIdQueryHandler : IRequestHandler<GetContactByIdQuery, Contact>
    {
        private readonly IContactRepository _contactRepository;

        public GetContactByIdQueryHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Contact> Handle(GetContactByIdQuery request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetByIdAsync(request.Id);

            if (contact == null)
                return default;

            return contact;
        }
    }
}
