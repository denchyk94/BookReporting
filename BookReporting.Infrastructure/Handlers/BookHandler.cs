using BookReporting.Domain.Constants;
using BookReporting.Infrastructure.Handlers.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookReporting.Infrastructure.Handlers
{
    public class BookHandler : IBookHandler
    {
        private char[] SplitCharacters = new char[] { ' ', ',', '.', '?', '!', ']', '[' };

        public int GetPagesCount(List<string> lines)
        {
            return (lines.Count / Constants.LineCount) + 1;
        }

        public (string BookName, string Author) GetBookHeaders(string path)
        {
            // Calculate name length
            var lastSlashIndex = path.LastIndexOf('\\');
            var extension = path.IndexOf('.');
            var length = extension - lastSlashIndex - 1;

            // Fetch book name
            var bookName = path.Substring(lastSlashIndex + 1, length);
            var bookHeaders = bookName.Split('-');

            return (bookHeaders[0].Trim(), bookHeaders[1].Trim());
        }

        public Dictionary<int, int> GetPageWordsCount(List<string> lines)
        {
            Dictionary<int, int> pageWordsCount = new Dictionary<int, int>();

            var pageCount = GetPagesCount(lines);
            // Process all pages, skip only the last one
            // Because last page may contain less lines that {Constants.LineCount}
            for (var i = 0; i < pageCount - 1; i++)
            {
                for (var j = i * Constants.LineCount; j < (i + 1) * Constants.LineCount; j++)
                {
                    var line = lines[j];
                    var words = line.Split(SplitCharacters, StringSplitOptions.RemoveEmptyEntries);

                    RefreshWordCountForPage(pageWordsCount, i, words.Length);
                }
            }

            // Process last page
            var lastPageLinesCount = lines.Count % Constants.LineCount;
            var lastPageIndex = pageCount - 1;
            var maxPageIndex = (lastPageIndex - 1) * Constants.LineCount + lastPageLinesCount;
            for (var i = (lastPageIndex - 1) * Constants.LineCount; i < maxPageIndex; i++)
            {
                var line = lines[i];
                var words = line.Split(SplitCharacters, StringSplitOptions.RemoveEmptyEntries);

                RefreshWordCountForPage(pageWordsCount, lastPageIndex, words.Length);
            }

            return pageWordsCount;
        }

        /// <summary>
        /// Simplified version
        /// One one line if checked for searched key
        /// </summary>
        /// <param name="lines"></param>
        /// <param name="searchKey"></param>
        /// <returns></returns>
        public List<int> GetPagesForSearckKey(List<string> lines, string searchKey)
        {
            // Find lines with the searched key
            var linesWithSearchedKey = new List<int>();
            for(var i = 0; i < lines.Count; i ++)
            {
                if (lines[i].Contains(searchKey))
                    linesWithSearchedKey.Add(i);
            }

            // Calculate pages based on the lines numbers
            var pagesWithSearchedKey = new HashSet<int>();
            foreach (var line in linesWithSearchedKey)
            {
                int page;
                if(line % Constants.LineCount != 0)
                    page = line / Constants.LineCount + 1;
                else
                    page = line / Constants.LineCount;

                if(!pagesWithSearchedKey.Contains(page))
                    pagesWithSearchedKey.Add(page);
            }

            return pagesWithSearchedKey.ToList();
        }

        /// <summary>
        /// Simplified implementation
        /// </summary>
        /// <param name="lines">Book lines</param>
        /// <returns>Word grouping</returns>
        public List<string> GetWordGroupings(List<string> lines)
        {
            return new List<string>
            {
                lines[0],
                lines[1]
            };
        }

        /// <summary>
        /// Simplified implementation
        /// </summary>
        /// <param name="lines">Book lines</param>
        /// <returns>Most used words</returns>
        public List<string> GetMostUsedWords(List<string> lines)
        {
            return new List<string>
            {
                lines[0]
            };
        }

        private void RefreshWordCountForPage(Dictionary<int, int> pageWordsCount, int pageIndex, int wordsCount)
        {
            if (pageWordsCount.ContainsKey(pageIndex))
                pageWordsCount[pageIndex] += wordsCount;
            else
                pageWordsCount[pageIndex] = wordsCount;
        }
    }
}
