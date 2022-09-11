using System;
using System.Collections.Generic;

namespace BookReporting.Domain.ValueObjects
{
    /// <summary>
    /// Researcher Book value object
    /// </summary>
    public readonly struct ResearcherBook
    {
        private readonly List<string> m_commonWordGroupings;

        public ResearcherBook(List<string> commonWordGroupings)
        {
            var minCount = Constants.Constants.MinimumWordGroupingCount;
            if (commonWordGroupings == null || commonWordGroupings.Count < minCount)
                throw new InvalidOperationException($"Word grouping count should >= {minCount}");

            m_commonWordGroupings = commonWordGroupings;
        }

        public List<string> GetWordGroupings() => m_commonWordGroupings;
    }
}
