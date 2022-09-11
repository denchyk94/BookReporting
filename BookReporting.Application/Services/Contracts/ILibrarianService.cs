using BookReporting.Application.Models;
using System.Threading.Tasks;

namespace BookReporting.Application.Services.Contracts
{
    /// <summary>
    /// Librarian service
    /// </summary
    public interface ILibrarianService
    {
        Task<LibrarianReportModel> Get(string path);
    }
}
