using BookReporting.Domain.AggregateRoots;
using BookReporting.Domain.ValueObjects;
using BookReporting.Infrastructure.Factories.Contracts;

namespace BookReporting.Infrastructure.Factories
{
    /// <summary>
    /// Researcher Factory
    /// </summary>
    public class ResearcherFactory : IResearcherFactory
    {
        public Researcher CreateResearcherInstance(Book book, ResearcherBook researcherBook)
        {
            return new Researcher
            {
                Book = book,
                ResearcherBook = researcherBook
            };
        }
    }
}
