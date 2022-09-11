using BookReporting.Application.Models;
using System.Threading.Tasks;

namespace BookReporting.Application.Services.Contracts
{
    /// <summary>
    /// Researcher service
    /// </summary
    public interface IResearcherService
    {
        Task<ResearcherReportModel> Get(string path);
    }
}
