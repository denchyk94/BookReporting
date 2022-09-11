using BookReporting.Application.Mappers.Contracts;
using BookReporting.Application.Models;
using BookReporting.Domain.AggregateRoots;

namespace BookReporting.Application.Mappers
{
    /// <summary>
    /// Student mapper
    /// </summary>
    public class StudentReportModelMapper : IMapper<Student, StudentReportModel>
    {
        public StudentReportModel Map(Student student)
        {
            return new StudentReportModel
            {
                BookName = student.Book.ToString(),
                FoundPagesForSearckKey = student.StudentBook.GetPagesForSearchKey(),
            };
        }
    }
}
