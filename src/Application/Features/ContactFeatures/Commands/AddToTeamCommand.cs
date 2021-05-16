using Domain.Interfaces;
using Domain.Services;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ContactFeatures.Commands
{
    public class AddToTeamCommand : IRequest<int>
    {
        public int ContactId { get; private set; }
        public int TeamId { get; private set; }
        public AddToTeamCommand(int conatctId, int teamId)
        {
            ContactId = ContactId;
            TeamId = teamId;
        }
    }

    public class AddToTeamCommandHandler : IRequestHandler<AddToTeamCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventStoreRepository _eventStoreRepository;
        public AddToTeamCommandHandler(IUnitOfWork unitOfWork,
            IEventStoreRepository eventStoreRepository)
        {
            _unitOfWork = unitOfWork;
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task<int> Handle(AddToTeamCommand request, CancellationToken ct)
        {
            var contact = await _unitOfWork.ContactRepository.GetByIdAsync(request.ContactId, ct);
            if (contact == null)
            {
                return default;
            }

            var team = await _unitOfWork.TeamRepository.GetByIdAsync(request.TeamId, ct);
            if (team == null)
            {
                return default;
            }


            contact.AddToTeam(request.TeamId, new TinderTeamPolicy(contact, team));

            await _unitOfWork.ContactRepository.UpdateAsync(contact, ct);
            await _unitOfWork.SaveChangesAsync(ct);
            _eventStoreRepository.Save(contact);
            return contact.Id;
        }
    }
}
