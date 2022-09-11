using BookReporting.Domain.AggregateRoots;
using BookReporting.Domain.ValueObjects;

namespace BookReporting.Infrastructure.Factories.Contracts
{
    /// <summary>
    /// Business Analyst Factory
    /// </summary>
    public interface IBusinessAnalystFactory
    {
        BusinessAnalyst CreateBusinessAnalystInstance(Book book, BusinessAnalystBook businessAnalystBook);
    }
}
