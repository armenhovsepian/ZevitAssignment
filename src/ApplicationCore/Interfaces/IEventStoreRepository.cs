using ApplicationCore.Entities;
using ApplicationCore.Events;
using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IEventStoreRepository
    {
        bool Exists(int id);
        List<IDomainEvent> LoadChanges(int id);
        void Save(Contact entity);
    }
}
