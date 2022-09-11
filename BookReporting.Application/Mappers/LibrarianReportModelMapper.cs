using BookReporting.Application.Mappers.Contracts;
using BookReporting.Application.Models;
using BookReporting.Domain.AggregateRoots;

namespace BookReporting.Application.Mappers
{
    /// <summary>
    /// Librarian mapper
    /// </summary>
    public class LibrarianReportModelMapper : IMapper<Librarian, LibrarianReportModel>
    {
        public LibrarianReportModel Map(Librarian librarian)
        {
            return new LibrarianReportModel
            {
                BookName = librarian.Book.ToString(),
                PagesNumber = librarian.LibrarianBook.GetPages(),
                WordCountPerPage = librarian.LibrarianBook.GetWordCount()
            };
        }
    }
}
