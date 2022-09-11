using BookReporting.Domain.AggregateRoots;
using BookReporting.Domain.ValueObjects;
using BookReporting.Infrastructure.Factories.Contracts;

namespace BookReporting.Infrastructure.Factories
{
    /// <summary>
    /// Librarian Factory
    /// </summary>
    public class LibrarianFactory : ILibrarianFactory
    {
        public Librarian CreateLibrarianInstance(Book book, LibrarianBook librarianBook)
        {
            return new Librarian
            {
                Book = book,
                LibrarianBook = librarianBook
            };
        }
    }
}
