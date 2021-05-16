namespace Domain.Entities.AggregatesModel
{
    public class ContactTeam
    {
        public int ContactId { get; private set; }
        public Contact Contact { get; private set; }
        public int TeamId { get; private set; }
        public Team Team { get; private set; }

        public ContactTeam(int contactId, int teamId)
        {
            ContactId = contactId;
            TeamId = teamId;
        }
    }
}
