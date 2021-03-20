using ApplicationCore.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Features.ContactFeatures.Commands
{
    public class DeleteContactCommand : IRequest<int>
    {
        public int Id { get; private set; }
        public DeleteContactCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, int>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        public DeleteContactCommandHandler(IContactRepository contactRepository, IEventStoreRepository eventStoreRepository)
        {
            _contactRepository = contactRepository;
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task<int> Handle(DeleteContactCommand request, CancellationToken ct)
        {
            var contact = await _contactRepository.GetByIdAsync(request.Id, ct);

            if (contact == null)
                return default;

            contact.Delete();
            await _contactRepository.DeleteAsync(contact, ct);
            _eventStoreRepository.Save(contact);
            return contact.Id;
        }
    }

}
