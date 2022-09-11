using BookReporting.Application.Models;
using System.Threading.Tasks;

namespace BookReporting.Application.Services.Contracts
{
    /// <summary>
    /// Student service
    /// </summary
    public interface IStudentService
    {
        Task<StudentReportModel> Get(string path, string searchString);
    }
}
