using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Web.Models;
using static Domain.Events.ContactEvents;

namespace Web.Controllers
{
    public class ChangesHistoryController : Controller
    {
        private readonly IEventStoreRepository _eventStoreRepository;
        public ChangesHistoryController(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public IActionResult Index(int id)
        {
            var changes = _eventStoreRepository.LoadChanges(id);

            var events = changes.Where(e => e is BaseContactEvent)
                .Select(e => (BaseContactEvent)e);

            var models = new List<ContactChangesModel>();
            foreach (var evt in events)
            {
                switch (evt)
                {
                    case ContactFullNameUpdated c:
                        models.Add(new ContactChangesModel
                        {
                            Id = evt.Id,
                            Date = evt.Created,
                            EventType = evt.GetType().Name,
                            MetaData = c.FullName
                        });
                        break;

                    case ContactEmailAddressUpdated c:
                        models.Add(new ContactChangesModel
                        {
                            Id = evt.Id,
                            Date = evt.Created,
                            EventType = evt.GetType().Name,
                            MetaData = c.EmailAddress
                        });
                        break;

                    case ContactPhoneNumberUpdated c:
                        models.Add(new ContactChangesModel
                        {
                            Id = evt.Id,
                            Date = evt.Created,
                            EventType = evt.GetType().Name,
                            MetaData = c.PhoneNumber
                        });
                        break;

                    case ContactAddressUpdated c:
                        models.Add(new ContactChangesModel
                        {
                            Id = evt.Id,
                            Date = evt.Created,
                            EventType = evt.GetType().Name,
                            MetaData = c.Address
                        });
                        break;

                    default:
                        models.Add(new ContactChangesModel
                        {
                            Id = evt.Id,
                            Date = evt.Created,
                            EventType = evt.GetType().Name
                        });
                        break;
                }
            }
            return View(models);
        }
    }
}
