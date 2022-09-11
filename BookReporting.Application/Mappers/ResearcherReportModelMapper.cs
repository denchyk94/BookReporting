using BookReporting.Application.Mappers.Contracts;
using BookReporting.Application.Models;
using BookReporting.Domain.AggregateRoots;

namespace BookReporting.Application.Mappers
{
    /// <summary>
    /// Researcher mapper
    /// </summary>
    public class ResearcherReportModelMapper : IMapper<Researcher, ResearcherReportModel>
    {
        public ResearcherReportModel Map(Researcher student)
        {
            return new ResearcherReportModel
            {
                BookName = student.Book.ToString(),
                WordGroupings = student.ResearcherBook.GetWordGroupings(),
            };
        }
    }
}
