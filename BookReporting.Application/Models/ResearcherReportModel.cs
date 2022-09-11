using System.Collections.Generic;
using System.Text;

namespace BookReporting.Application.Models
{
    /// <summary>
    /// Researcher report model
    /// </summary>
    public class ResearcherReportModel : BaseReportModel
    {
        public string BookName { get; set; }
        public List<string> WordGroupings { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            
            stringBuilder.AppendLine($"Book Name: {BookName}");
            stringBuilder.AppendLine("Common word groupings are:");
            foreach(var group in WordGroupings)
            {
                stringBuilder.AppendLine(group);
            }

            return stringBuilder.ToString();
        }
    }
}
