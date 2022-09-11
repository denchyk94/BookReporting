using System.Collections.Generic;

namespace BookReporting.Infrastructure.Handlers.Contracts
{
    public interface IBookHandler
    {
        int GetPagesCount(List<string> lines);
        (string BookName, string Author) GetBookHeaders(string path);
        Dictionary<int, int> GetPageWordsCount(List<string> lines);
        List<int> GetPagesForSearckKey(List<string> lines, string searchKey);
        List<string> GetWordGroupings(List<string> lines);
        List<string> GetMostUsedWords(List<string> lines);
    }
}
