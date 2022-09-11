using BookReporting.Domain.AggregateRoots;
using BookReporting.Domain.ValueObjects;

namespace BookReporting.Infrastructure.Factories.Contracts
{
    /// <summary>
    /// Researcher Factory
    /// </summary>
    public interface IResearcherFactory
    {
        Researcher CreateResearcherInstance(Book book, ResearcherBook researcherBook);
    }
}
