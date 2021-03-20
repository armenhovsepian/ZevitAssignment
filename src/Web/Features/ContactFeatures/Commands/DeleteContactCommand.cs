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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventStoreRepository _eventStoreRepository;
        public DeleteContactCommandHandler(IUnitOfWork unitOfWork, IEventStoreRepository eventStoreRepository)
        {
            _unitOfWork = unitOfWork;
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task<int> Handle(DeleteContactCommand request, CancellationToken ct)
        {
            var contact = await _unitOfWork.ContactRepository.GetByIdAsync(request.Id, ct);

            if (contact == null)
                return default;

            contact.Delete();
            await _unitOfWork.ContactRepository.DeleteAsync(contact, ct);
            await _unitOfWork.SaveChangesAsync(ct);
            _eventStoreRepository.Save(contact);
            return contact.Id;
        }
    }

}
