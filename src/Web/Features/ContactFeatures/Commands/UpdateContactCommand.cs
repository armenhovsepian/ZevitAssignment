using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Features.ContactFeatures.Commands
{
    public class UpdateContactCommand : IRequest<int>
    {
        public ContactFormModel Model { get; private set; }
        public UpdateContactCommand(ContactFormModel model)
        {
            Model = model;
        }
    }


    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, int>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEventStoreRepository _eventStoreRepository;
        public UpdateContactCommandHandler(IUnitOfWork unitOfWork, IEventStoreRepository eventStoreRepository)
        {
            _unitOfWork = unitOfWork;
            _eventStoreRepository = eventStoreRepository;
        }

        public async Task<int> Handle(UpdateContactCommand request, CancellationToken ct)
        {
            var contact = await _unitOfWork.ContactRepository.GetByIdAsync(request.Model.Id, ct);

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

            await _unitOfWork.ContactRepository.UpdateAsync(contact, ct);
            await _unitOfWork.SaveChangesAsync(ct);
            _eventStoreRepository.Save(contact);
            return contact.Id;
        }
    }
}
