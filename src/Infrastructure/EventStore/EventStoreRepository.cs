using ApplicationCore.Entities.AggregatesModel;
using ApplicationCore.Events;
using ApplicationCore.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Infrastructure.EventStore
{
    public class EventStoreRepository : IEventStoreRepository
    {
        /// <summary>
        /// to see real world event sourcing with EventStore please fallow this link:
        /// https://github.com/armenhovsepian/EventSourcingWithEventStore
        /// </summary>
        private static Dictionary<int, List<IDomainEvent>> FakeEventStore = new Dictionary<int, List<IDomainEvent>>();
        public bool Exists(int id)
        {
            return FakeEventStore.ContainsKey(id);
        }

        public List<IDomainEvent> LoadChanges(int id)
        {
            if (FakeEventStore.TryGetValue(id, out List<IDomainEvent> changes))
                return changes;

            return Enumerable.Empty<IDomainEvent>().ToList();
        }

        public void Save(Contact entity)
        {
            if (FakeEventStore.TryGetValue(entity.Id, out List<IDomainEvent> changes))
                changes.AddRange(entity.GetChanges());
            else
                FakeEventStore.Add(entity.Id, entity.GetChanges().ToList());
        }
    }
}
