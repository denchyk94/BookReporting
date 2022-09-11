using BookReporting.Domain.AggregateRoots;
using BookReporting.Domain.ValueObjects;
using BookReporting.Infrastructure.Factories.Contracts;
using BookReporting.Infrastructure.Handlers.Contracts;
using BookReporting.Infrastructure.Repositories.Contracts;
using System.Threading.Tasks;

namespace BookReporting.Infrastructure.Repositories
{
    public class StudentRepository : IStudentRepository<Student>
    {
        private readonly IStudentFactory m_studentFactory;
        private readonly IBookHandler m_bookHandler;
        private readonly IFileRepository m_fileHandler;

        public StudentRepository(IStudentFactory studentFactory, IBookHandler bookHandler, IFileRepository fileHandler)
        {
            m_studentFactory = studentFactory;
            m_bookHandler = bookHandler;
            m_fileHandler = fileHandler;
        }

        public async Task<Student> Get(string path, string searchKey)
        {
            var bookHeaders = m_bookHandler.GetBookHeaders(path);
            var book = new Book(bookHeaders.BookName, bookHeaders.Author);

            var lines = await m_fileHandler.ReadAllLinesAsync(path);
            var pagesForSearckKey = m_bookHandler.GetPagesForSearckKey(lines, searchKey);
            var studentBook = new StudentBook(pagesForSearckKey);

            var student = m_studentFactory.CreateStudentInstance(book, studentBook);
            return student;
        }
    }
}
