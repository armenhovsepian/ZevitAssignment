using Domain.Events;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities.AggregatesModel
{
    public class Team : BaseEntity, IAggregationRoot
    {
        [NotMapped]
        public List<IDomainEvent> RecordedEvents { get; private set; }
        private Team()
        {

        }

        public Team(TeamName name)
        {
            Name = name;
        }

        public TeamName Name { get; private set; }
    }
}
