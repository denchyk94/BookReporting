using BookReporting.Infrastructure.Repositories.Contracts;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace BookReporting.Infrastructure.Repositories
{
    public class FileRepository : IFileRepository
    {
        /// <summary>
        /// This is the same default buffer size as
        /// <see cref="StreamReader"/> and <see cref="FileStream"/>.
        /// </summary>
        private const int DefaultBufferSize = 4096;

        /// <summary>
        /// Indicates that
        /// 1. The file is to be used for asynchronous reading.
        /// 2. The file is to be accessed sequentially from beginning to end.
        /// </summary>
        private const FileOptions DefaultOptions = FileOptions.Asynchronous | FileOptions.SequentialScan;

        public async Task<List<string>> ReadAllLinesAsync(string path)
        {
            var lines = new List<string>();

            using (var stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read, DefaultBufferSize, DefaultOptions))
            {
                using (var reader = new StreamReader(stream, Encoding.UTF8))
                {
                    string line;
                    while ((line = await reader.ReadLineAsync()) != null)
                    {
                        lines.Add(line);
                    }
                }
            }

            return lines;
        }
    }
}
