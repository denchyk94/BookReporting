using BookReporting.Domain.ValueObjects;

namespace BookReporting.Domain.AggregateRoots
{
    /// <summary>
    /// Researcher aggregate root
    /// </summary>
    public class Researcher : BaseBookAggregateRoot
    {
        public ResearcherBook ResearcherBook { get; set; }
    }
}
