namespace ApplicationCore.Entities.AggregatesModel
{
    public class Team : BaseEntity, IAggregationRoot
    {
        private Team()
        {

        }

        public Team(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
