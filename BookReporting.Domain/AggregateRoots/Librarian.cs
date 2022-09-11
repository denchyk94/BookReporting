using BookReporting.Domain.ValueObjects;

namespace BookReporting.Domain.AggregateRoots
{
    /// <summary>
    /// Librarian aggregate root
    /// </summary>
    public class Librarian : BaseBookAggregateRoot
    {
        public LibrarianBook LibrarianBook { get; set; }
    }
}
