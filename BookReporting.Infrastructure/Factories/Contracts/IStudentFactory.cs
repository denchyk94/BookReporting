using BookReporting.Domain.AggregateRoots;
using BookReporting.Domain.ValueObjects;

namespace BookReporting.Infrastructure.Factories.Contracts
{
    /// <summary>
    /// Student Factory
    /// </summary>
    public interface IStudentFactory
    {
        Student CreateStudentInstance(Book book, StudentBook studentBook);
    }
}
