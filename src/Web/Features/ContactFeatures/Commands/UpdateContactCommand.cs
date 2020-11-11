using ApplicationCore.Interfaces;
using ApplicationCore.ValueObject;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Features.ContactFeatures.Commands
{
    public class UpdateContactCommand : IRequest<int>
    {
        public ContactFormModel Model { get; set; }
        public UpdateContactCommand(ContactFormModel model)
        {
            Model = model;
        }
    }


    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, int>
    {
        private readonly IContactRepository _contactRepository;
        public UpdateContactCommandHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<int> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = await _contactRepository.GetByIdAsync(request.Model.Id);

            if (contact == null)
            {
                return default;
            }
            else
            {
                contact.UpdateFullName(new FullName(request.Model.FirstName, request.Model.LastName));
                contact.UpdateEmailAddress(new EmailAddress(request.Model.EmailAddress));
                contact.UpdatePhoneNumber(new PhoneNumber(request.Model.PhoneNumber));
                contact.UpdateAddress(new Address(request.Model.Street, request.Model.City, request.Model.State, request.Model.Country, request.Model.ZipCode));
            }

            await _contactRepository.AddAsync(contact);
            return contact.Id;
        }
    }
}
