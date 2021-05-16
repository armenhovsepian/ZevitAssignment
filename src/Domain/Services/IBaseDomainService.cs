namespace Domain.Services
{
    /// <summary>
    /// Domain Service is responsible for:
    /// Piece of domain logic that don't fit into any of the existing entities/aggregates
    /// Domain services have no identity or state
    /// Domain services responsibility is to orchestrate business logic using Entities and Value objects
    /// Domain services don’t depend on the external dependencies. (Repositores / Infrustructure Services)
    /// The input parameters of Domain service must be Entities / Aggregates / Value Objects / Prmative data Types
    /// </summary>
    public interface IBaseDomainService
    {
        void Apply();

    }
}
