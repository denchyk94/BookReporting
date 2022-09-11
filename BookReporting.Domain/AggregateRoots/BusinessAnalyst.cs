using BookReporting.Domain.ValueObjects;

namespace BookReporting.Domain.AggregateRoots
{
    /// <summary>
    /// Business Analyst aggregate root
    /// </summary>
    public class BusinessAnalyst : BaseBookAggregateRoot
    {
        public BusinessAnalystBook BusinessAnalystBook { get; set; }
    }
}
