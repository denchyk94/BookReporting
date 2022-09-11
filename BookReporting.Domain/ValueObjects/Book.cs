using System;

namespace BookReporting.Domain.ValueObjects
{
    /// <summary>
    /// Book value object
    /// </summary>
    public readonly struct Book
    {
        private readonly string m_bookName;
        private readonly string m_author;

        public Book(string bookName, string author)
        {
            if (string.IsNullOrWhiteSpace(bookName))
                throw new ArgumentNullException($"Book name does not have any value");

            m_bookName = bookName;

            if (string.IsNullOrWhiteSpace(author))
                throw new ArgumentNullException($"Author does not have any value");

            m_author = author;
        }

        public override string ToString()
        {
            return $"{m_bookName} - {m_author}";
        }
    }
}
