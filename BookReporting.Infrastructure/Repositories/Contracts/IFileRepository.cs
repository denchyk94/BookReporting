using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookReporting.Infrastructure.Repositories.Contracts
{
    public interface IFileRepository
    {
        Task<List<string>> ReadAllLinesAsync(string path);
    }
}
