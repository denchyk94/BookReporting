using BookReporting.Application.Mappers.Contracts;
using BookReporting.Application.Models;
using BookReporting.Domain.AggregateRoots;

namespace BookReporting.Application.Mappers
{
    /// <summary>
    /// Business Analyst mapper
    /// </summary>
    public class BusinessAnalystReportModelMapper : IMapper<BusinessAnalyst, BusinessAnalystReportModel>
    {
        public BusinessAnalystReportModel Map(BusinessAnalyst businessAnalyst)
        {
            return new BusinessAnalystReportModel
            {
                BookName = businessAnalyst.Book.ToString(),
                MostUsedWords = businessAnalyst.BusinessAnalystBook.GetMostUsedWords(),
            };
        }
    }
}
