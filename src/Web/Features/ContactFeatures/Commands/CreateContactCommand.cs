using ApplicationCore.Entities;
using ApplicationCore.Entities.AggregatesModel;
using ApplicationCore.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Features.ContactFeatures.Commands
{
    public class CreateContactCommand : IRequest<int>
    {
        public ContactFormModel Model { get; private set; }
        public CreateContactCommand(ContactFormModel model)
        {
            Model = model;
        }
    }

    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, int>
    {
        private readonly IContactRepository _contactRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        public CreateContactCommandHandler(IContactRepository contactRepository, IEventStoreRepository eventStoreRepository)
        {
            _contactRepository = contactRepository;
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task<int> Handle(CreateContactCommand request, CancellationToken ct)
        {
            var contact = new Contact(
                new FullName(request.Model.FirstName, request.Model.LastName),
                new EmailAddress(request.Model.EmailAddress),
                new PhoneNumber(request.Model.PhoneNumber),
                new Address(request.Model.Street, request.Model.City, request.Model.State, request.Model.Country, request.Model.ZipCode)
                );

            await _contactRepository.AddAsync(contact, ct);
            _eventStoreRepository.Save(contact);
            return contact.Id;
        }
    }
}
