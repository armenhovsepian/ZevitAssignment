using Domain.Entities.AggregatesModel;
using Domain.Exceptions;
using Domain.Helpers;

namespace Domain.Services
{
    public class TinderTeamPolicy : IBaseDomainService
    {

        private Contact _contact; // Contact AggregateRoot
        private Team _team; // Team AggregateRoot
        public TinderTeamPolicy(Contact contact, Team team)
        {
            _contact = contact;
            _team = team;
        }

        public void Apply()
        {
            if (_team.Name.Value == "Tinder"
                && DateTimeHelpers.CalculateAge(_contact.DateOfBirth.Value) < 18)
                throw new ContactException("To join to tinder team, the age cannnot be less than 18 years.");

        }
    }
}
