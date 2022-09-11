using BookReporting.Application.Mappers.Contracts;
using BookReporting.Application.Models;
using BookReporting.Application.Services.Contracts;
using BookReporting.Domain.AggregateRoots;
using BookReporting.Infrastructure.Repositories.Contracts;
using System.Threading.Tasks;

namespace BookReporting.Application.Services
{
    /// <summary>
    /// Student service
    /// </summary
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository<Student> m_repository;
        private readonly IMapper<Student, StudentReportModel> m_mapper;

        public StudentService(IStudentRepository<Student> repository, IMapper<Student, StudentReportModel> mapper)
        {
            m_repository = repository;
            m_mapper = mapper;
        }

        public async Task<StudentReportModel> Get(string path, string searchString)
        {
            var librarian = await m_repository.Get(path, searchString);

            var model = m_mapper.Map(librarian);
            return model;
        }
    }
}
