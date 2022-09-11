using BookReporting.Infrastructure.Handlers.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BookReporting.Infrastructure.UnitTests.Handlers.BookHandlerTests
{
    public class BookHandlerGetPagesForSearckKeyTests
    {
        private IBookHandler m_bookHandler;

        public BookHandlerGetPagesForSearckKeyTests()
        {
            m_bookHandler = new Infrastructure.Handlers.BookHandler();
        }

        [Fact]
        public async Task GetPagesForSearckKey_OnePagesWithSearchKey_FirstPageIndexReturned()
        {
            // Arrange
            var lines = new List<string>
            {
                "test test aaaaaaaaaaaaaaaaa",
                "test test bbbbbbbbbbbbbbbbb"
            };
            var searchKey = "test";

            // Act
            var result = m_bookHandler.GetPagesForSearckKey(lines, searchKey);

            // Assert
            Assert.Single(result);
            Assert.Equal(1, result[0]);
        }
    }
}
