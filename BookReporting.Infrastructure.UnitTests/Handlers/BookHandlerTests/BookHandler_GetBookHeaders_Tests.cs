using BookReporting.Infrastructure.Handlers.Contracts;
using System.Threading.Tasks;
using Xunit;

namespace BookReporting.Infrastructure.UnitTests.Handlers.BookHandlerTests
{
    public class BookHandlerGetBookHeadersTests
    {
        private IBookHandler m_bookHandler;

        public BookHandlerGetBookHeadersTests()
        {
            m_bookHandler = new Infrastructure.Handlers.BookHandler();
        }

        [Fact]
        public async Task GetBookHeaders_CorrectPath_NameAndAuthorReturned()
        {
            // Arrange
            string path = "\\test name - test author.txt";

            // Act
            var result = m_bookHandler.GetBookHeaders(path);

            // Assert
            Assert.Equal("test name", result.BookName);
            Assert.Equal("test author", result.Author);
        }
    }
}
