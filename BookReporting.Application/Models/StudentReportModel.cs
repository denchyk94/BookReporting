using System.Collections.Generic;
using System.Text;

namespace BookReporting.Application.Models
{
    /// <summary>
    /// Student report model
    /// </summary>
    public class StudentReportModel : BaseReportModel
    {
        public string BookName { get; set; }
        public string SearchKey { get; set; }
        public List<int> FoundPagesForSearckKey { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            stringBuilder.AppendLine($"Book Name: {BookName}");
            stringBuilder.AppendLine($"Search Key: {SearchKey}");
            stringBuilder.AppendLine("Search key was found on the pages:");
            stringBuilder.AppendLine(string.Join(", ", FoundPagesForSearckKey));

            return stringBuilder.ToString();
        }
    }
}
