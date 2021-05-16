using Domain.Dtos;
using Domain.Entities;
using Domain.Entities.AggregatesModel;
using Domain.Exceptions;
using Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ContactFeatures.Commands
{
    /// <summary>
    /// Command / Application Service is responsible for
    /// • Orchestrate calls to repositories and domain objects
	/// • Managing transactions and units of work
	/// • Communicating with other services via HTTP/REST, Message Queue
	/// • Calling out to infrastructure services such as e‐mail clients of payment gateways.
	/// • Raising and handling domain events
    /// • Logging(EventLogging)
    /// </summary>
    public class CreateContactCommand : IRequest<int>
    {
        public ContactDto Model { get; private set; }
        public CreateContactCommand(ContactDto model)
        {
            Model = model;
        }
    }

    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IPurgomalumClient _purgomalumClient;
        public CreateContactCommandHandler(IUnitOfWork unitOfWork,
            IPurgomalumClient purgomalumClient,
            IEventStoreRepository eventStoreRepository)
        {
            _unitOfWork = unitOfWork;
            _eventStoreRepository = eventStoreRepository;
            _purgomalumClient = purgomalumClient;
        }

        public async Task<int> Handle(CreateContactCommand request, CancellationToken ct)
        {
            ///////
            /// Domain logic fragmentation:
            /// Splitting the decision-making process between the domain layer and application layer
            ///////
            if (await _unitOfWork.ContactRepository.IsEmailAddressExists(request.Model.EmailAddress))
                throw new ContactException("Email address should be unique");

            if (await _purgomalumClient.CheckForProfanity(request.Model.FirstName))
                throw new ContactException("The FirstName contains profanity");

            if (await _purgomalumClient.CheckForProfanity(request.Model.LastName))
                throw new ContactException("The LastName contains profanity");
            ///////
            ///
            ///////

            var contact = new Contact(
                new FullName(request.Model.FirstName, request.Model.LastName),
                new EmailAddress(request.Model.EmailAddress),
                new PhoneNumber(request.Model.PhoneNumber),
                new Address(request.Model.Street, request.Model.City, request.Model.State, request.Model.Country, request.Model.ZipCode),
                new DateOfBirth(request.Model.DateOfBirth)
                );

            await _unitOfWork.ContactRepository.AddAsync(contact, ct);
            await _unitOfWork.SaveChangesAsync(ct);
            _eventStoreRepository.Save(contact);
            return contact.Id;
        }
    }
}
