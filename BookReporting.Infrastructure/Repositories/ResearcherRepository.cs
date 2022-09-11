using BookReporting.Domain.AggregateRoots;
using BookReporting.Domain.ValueObjects;
using BookReporting.Infrastructure.Factories.Contracts;
using BookReporting.Infrastructure.Handlers.Contracts;
using BookReporting.Infrastructure.Repositories.Contracts;
using System.Threading.Tasks;

namespace BookReporting.Infrastructure.Repositories
{
    public class ResearcherRepository : IResearcherRepository<Researcher>
    {
        private readonly IResearcherFactory m_researcherFactory;
        private readonly IBookHandler m_bookHandler;
        private readonly IFileRepository m_fileHandler;

        public ResearcherRepository(IResearcherFactory researcherFactory, IBookHandler bookHandler, IFileRepository fileHandler)
        {
            m_researcherFactory = researcherFactory;
            m_bookHandler = bookHandler;
            m_fileHandler = fileHandler;
        }

        public async Task<Researcher> Get(string path)
        {
            var bookHeaders = m_bookHandler.GetBookHeaders(path);
            var book = new Book(bookHeaders.BookName, bookHeaders.Author);

            var lines = await m_fileHandler.ReadAllLinesAsync(path);
            var wordGroupings = m_bookHandler.GetWordGroupings(lines);
            var researcherBook = new ResearcherBook(wordGroupings);

            var student = m_researcherFactory.CreateResearcherInstance(book, researcherBook);
            return student;
        }
    }
}
