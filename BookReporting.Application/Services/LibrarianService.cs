using BookReporting.Application.Mappers.Contracts;
using BookReporting.Application.Models;
using BookReporting.Application.Services.Contracts;
using BookReporting.Domain.AggregateRoots;
using BookReporting.Infrastructure.Repositories.Contracts;
using System.Threading.Tasks;

namespace BookReporting.Application.Services
{
    /// <summary>
    /// Librarian service
    /// </summary
    public class LibrarianService : ILibrarianService
    {
        private readonly ILibrarianRepository<Librarian> m_repository;
        private readonly IMapper<Librarian, LibrarianReportModel> m_mapper;

        public LibrarianService(ILibrarianRepository<Librarian> repository, IMapper<Librarian, LibrarianReportModel> mapper)
        {
            m_repository = repository;
            m_mapper = mapper;
        }

        public async Task<LibrarianReportModel> Get(string path)
        {
            var librarian = await m_repository.Get(path);

            var model = m_mapper.Map(librarian);
            return model;
        }
    }
}
