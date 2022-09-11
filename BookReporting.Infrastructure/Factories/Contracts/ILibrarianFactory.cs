using BookReporting.Domain.AggregateRoots;
using BookReporting.Domain.ValueObjects;

namespace BookReporting.Infrastructure.Factories.Contracts
{
    /// <summary>
    /// Librarian Factory
    /// </summary>
    public interface ILibrarianFactory
    {
        Librarian CreateLibrarianInstance(Book book, LibrarianBook librarianBook);
    }
}
