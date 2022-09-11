using System;
using System.Collections.Generic;
using System.Linq;

namespace BookReporting.Domain.ValueObjects
{
    /// <summary>
    /// Librarian Book value object
    /// </summary>
    public readonly struct LibrarianBook
    {
        private readonly int m_numberOfPages;
        private readonly Dictionary<int, int> m_wordCountPerPage;

        public LibrarianBook(int numberOfPages, Dictionary<int, int> wordCountPerPage)
        {
            if (numberOfPages <= 0)
                throw new InvalidOperationException($"Number of pages should be greater that zero");

            m_numberOfPages = numberOfPages;

            if (wordCountPerPage == null || !wordCountPerPage.Any())
                throw new InvalidOperationException($"Word count per page dictionary should not be empty");

            m_wordCountPerPage = wordCountPerPage;
        }

        public int GetPages() => m_numberOfPages;

        public Dictionary<int, int> GetWordCount() => m_wordCountPerPage;
    }
}
