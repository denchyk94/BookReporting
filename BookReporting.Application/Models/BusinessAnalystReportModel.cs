using System.Collections.Generic;
using System.Text;

namespace BookReporting.Application.Models
{
    /// <summary>
    /// Business Analyst report model
    /// </summary>
    public class BusinessAnalystReportModel : BaseReportModel
    {
        public string BookName { get; set; }
        public List<string> MostUsedWords { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            stringBuilder.AppendLine($"Book Name: {BookName}");
            stringBuilder.AppendLine("Most used words are:");
            foreach(var word in MostUsedWords)
            {
                stringBuilder.AppendLine(word);
            }

            return stringBuilder.ToString();
        }
    }
}
