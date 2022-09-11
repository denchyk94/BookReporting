using BookReporting.Domain.AggregateRoots;
using BookReporting.Domain.ValueObjects;
using BookReporting.Infrastructure.Factories.Contracts;

namespace BookReporting.Infrastructure.Factories
{
    /// <summary>
    /// Business Analyst Factory
    /// </summary>
    public class BusinessAnalystFactory : IBusinessAnalystFactory
    {
        public BusinessAnalyst CreateBusinessAnalystInstance(Book book, BusinessAnalystBook businessAnalystBook)
        {
            return new BusinessAnalyst
            {
                Book = book,
                BusinessAnalystBook = businessAnalystBook
            };
        }
    }
}
