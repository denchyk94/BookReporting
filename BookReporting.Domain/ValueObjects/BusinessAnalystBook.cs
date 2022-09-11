using System;
using System.Collections.Generic;
using System.Linq;

namespace BookReporting.Domain.ValueObjects
{
    /// <summary>
    /// Business Analyst Book value object
    /// </summary>
    public readonly struct BusinessAnalystBook
    {
        private readonly List<string> m_mostUsedWords;

        public BusinessAnalystBook(List<string> mostUsedWords)
        {
            if (mostUsedWords == null || !mostUsedWords.Any())
                throw new InvalidOperationException($"Most used words should not be empty");

            m_mostUsedWords = mostUsedWords;
        }

        public List<string> GetMostUsedWords() => m_mostUsedWords;
    }
}
