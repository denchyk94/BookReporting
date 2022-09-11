using BookReporting.Domain.ValueObjects;

namespace BookReporting.Domain.AggregateRoots
{
    /// <summary>
    /// Student aggregate root
    /// </summary>
    public class Student : BaseBookAggregateRoot
    {
        public StudentBook StudentBook { get; set; }
    }
}
