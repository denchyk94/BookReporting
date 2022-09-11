using BookReporting.Application.Models;
using System.Threading.Tasks;

namespace BookReporting.Application.Services.Contracts
{
    /// <summary>
    /// Business Analyst service
    /// </summary>
    public interface IBusinessAnalystService
    {
        Task<BusinessAnalystReportModel> Get(string path);
    }
}
