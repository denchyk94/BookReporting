using System;
using System.Collections.Generic;

namespace BookReporting.Domain.ValueObjects
{
    /// <summary>
    /// Student Book value object
    /// </summary>
    public readonly struct StudentBook
    {
        private readonly List<int> m_foundPagesForSearckKey;

        public StudentBook(List<int> foundPagesForSearckKey)
        {
            if (foundPagesForSearckKey == null)
                throw new InvalidOperationException($"Found pages collection should not be null");

            m_foundPagesForSearckKey = foundPagesForSearckKey;
        }

        public List<int> GetPagesForSearchKey() => m_foundPagesForSearckKey;
    }
}
