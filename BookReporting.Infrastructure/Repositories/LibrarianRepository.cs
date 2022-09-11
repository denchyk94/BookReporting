using BookReporting.Domain.AggregateRoots;
using BookReporting.Domain.ValueObjects;
using BookReporting.Infrastructure.Factories.Contracts;
using BookReporting.Infrastructure.Handlers.Contracts;
using BookReporting.Infrastructure.Repositories.Contracts;
using System.Threading.Tasks;

namespace BookReporting.Infrastructure.Repositories
{
    public class LibrarianRepository : ILibrarianRepository<Librarian>
    {
        private readonly ILibrarianFactory m_librarianFactory;
        private readonly IBookHandler m_bookHandler;
        private readonly IFileRepository m_fileHandler;

        public LibrarianRepository(ILibrarianFactory librarianFactory, IBookHandler bookHandler, IFileRepository fileHandler)
        {
            m_librarianFactory = librarianFactory;
            m_bookHandler = bookHandler;
            m_fileHandler = fileHandler;
        }

        public async Task<Librarian> Get(string path)
        {
            var bookHeaders = m_bookHandler.GetBookHeaders(path);
            var book = new Book(bookHeaders.BookName, bookHeaders.Author);

            var lines = await m_fileHandler.ReadAllLinesAsync(path);
            var pageCount = m_bookHandler.GetPagesCount(lines);
            var wordCountPerPage = m_bookHandler.GetPageWordsCount(lines);
            var librarianBook = new LibrarianBook(pageCount, wordCountPerPage);

            var librarian = m_librarianFactory.CreateLibrarianInstance(book, librarianBook);
            return librarian;
        }
    }
}
