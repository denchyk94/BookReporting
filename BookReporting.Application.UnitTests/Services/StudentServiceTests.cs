using System.Threading.Tasks;
using BookReporting.Application.Mappers;
using BookReporting.Application.Mappers.Contracts;
using BookReporting.Application.Models;
using BookReporting.Application.Services;
using BookReporting.Application.Services.Contracts;
using BookReporting.Domain.AggregateRoots;
using BookReporting.Infrastructure.Repositories.Contracts;
using Moq;
using Xunit;

namespace BookReporting.Application.UnitTests.Services
{
    public class StudentServiceTests
    {
        private readonly Mock<IStudentRepository<Student>> m_repositoryMock;
        private readonly IMapper<Student, StudentReportModel> m_mapper;

        private IStudentService m_studentService;

        public StudentServiceTests()
        {
            m_repositoryMock = new Mock<IStudentRepository<Student>>();
            m_mapper = new StudentReportModelMapper();

            m_studentService = new StudentService(m_repositoryMock.Object, m_mapper);
        }

        [Fact]
        public async Task Get_WhenInvoked_RepositoryGetMethodInvokedOnce()
        {
            // Arrange
            string path = "test path";
            string searchKey = "test search key";

            // Act
            var result = await m_studentService.Get(path, searchKey);

            // Assert
            m_repositoryMock.Verify(x => x.Get(path, searchKey), Times.Once);
        }
    }
}
