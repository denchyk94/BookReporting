using System.Collections.Generic;
using System.Text;

namespace BookReporting.Application.Models
{
    /// <summary>
    /// Librarian report model
    /// </summary>
    public class LibrarianReportModel : BaseReportModel
    {
        public string BookName { get; set; }
        public int PagesNumber { get; set; }
        public Dictionary<int, int> WordCountPerPage { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            stringBuilder.AppendLine($"BookName: {BookName}");
            stringBuilder.AppendLine($"PagesNumber: {PagesNumber}");
            stringBuilder.AppendLine("WordCountPerPage:");
            foreach (var item in WordCountPerPage)
            {
                stringBuilder.AppendLine($"Page {item.Key}: {item.Value}");
            }

            return stringBuilder.ToString();
        }
    }
}
