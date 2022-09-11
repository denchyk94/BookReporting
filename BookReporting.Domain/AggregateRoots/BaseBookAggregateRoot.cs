using BookReporting.Domain.ValueObjects;

namespace BookReporting.Domain.AggregateRoots
{
    /// <summary>
    /// Base aggregate root with Book
    /// </summary>
    public class BaseBookAggregateRoot : IAggregateRoot
    {
        public Book Book { get; set; }
    }
}
