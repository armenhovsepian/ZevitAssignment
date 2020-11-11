using ApplicationCore.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Web.Features.ContactFeatures.Commands
{
    public class DeleteContactCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteContactCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand, int>
    {
        private readonly IContactRepository _contactRepository;
        public DeleteContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<int> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetByIdAsync(request.Id);

            if (contact == null)
                return default;

            await _contactRepository.DeleteAsync(contact);
            return contact.Id;
        }
    }

}
