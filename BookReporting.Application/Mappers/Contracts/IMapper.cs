using BookReporting.Application.Models;
using BookReporting.Domain.AggregateRoots;

namespace BookReporting.Application.Mappers.Contracts
{
    /// <summary>
    /// Custom mapper from aggreagate root to report model
    /// </summary>
    /// <typeparam name="TAggregateRoot">Aggregate Root</typeparam>
    /// <typeparam name="TReportModel">Report Model</typeparam>
    public interface IMapper<TAggregateRoot, TReportModel>
        where TAggregateRoot : IAggregateRoot
        where TReportModel : BaseReportModel 
    {
        /// <summary>
        /// Map method
        /// </summary>
        /// <param name="root">Aggregate root</param>
        /// <returns>Report model</returns>
        TReportModel Map(TAggregateRoot root);
    }
}
