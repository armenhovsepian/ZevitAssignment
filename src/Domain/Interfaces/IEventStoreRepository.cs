using Domain.Entities.AggregatesModel;
using Domain.Events;
using System.Collections.Generic;

namespace Domain.Interfaces
{
    public interface IEventStoreRepository
    {
        bool Exists(int id);
        List<IDomainEvent> LoadChanges(int id);
        void Save(Contact entity);
    }
}
