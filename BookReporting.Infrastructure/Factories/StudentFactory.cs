using BookReporting.Domain.AggregateRoots;
using BookReporting.Domain.ValueObjects;
using BookReporting.Infrastructure.Factories.Contracts;

namespace BookReporting.Infrastructure.Factories
{
    /// <summary>
    /// Student Factory
    /// </summary>
    public class StudentFactory : IStudentFactory
    {
        public Student CreateStudentInstance(Book book, StudentBook studentBook)
        {
            return new Student
            {
                Book = book,
                StudentBook = studentBook
            };
        }
    }
}
