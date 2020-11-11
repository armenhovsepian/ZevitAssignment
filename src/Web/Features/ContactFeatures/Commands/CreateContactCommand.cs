using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore.ValueObject;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Features.ContactFeatures.Commands
{
    public class CreateContactCommand: IRequest<int>
    {
        public ContactFormModel Model { get; set; }
        public CreateContactCommand(ContactFormModel model)
        {
            Model = model;
        }
    }

    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, int>
    {
        private readonly IContactRepository _contactRepository;
        public CreateContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<int> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact(
                new FullName(request.Model.FirstName, request.Model.LastName),
                new EmailAddress(request.Model.EmailAddress),
                new PhoneNumber(request.Model.PhoneNumber),
                new Address(request.Model.Street, request.Model.City, request.Model.State, request.Model.Country, request.Model.ZipCode)
                );

            await _contactRepository.AddAsync(contact);
            return contact.Id;
        }
    }
}
