using BookReporting.Application.Mappers.Contracts;
using BookReporting.Application.Models;
using BookReporting.Application.Services.Contracts;
using BookReporting.Domain.AggregateRoots;
using BookReporting.Infrastructure.Repositories.Contracts;
using System.Threading.Tasks;

namespace BookReporting.Application.Services
{
    /// <summary>
    /// Business Analyst service
    /// </summary
    public class BusinessAnalystService : IBusinessAnalystService
    {
        private readonly IBusinessAnalystRepository<BusinessAnalyst> m_repository;
        private readonly IMapper<BusinessAnalyst, BusinessAnalystReportModel> m_mapper;

        public BusinessAnalystService(IBusinessAnalystRepository<BusinessAnalyst> repository, IMapper<BusinessAnalyst, BusinessAnalystReportModel> mapper)
        {
            m_repository = repository;
            m_mapper = mapper;
        }

        public async Task<BusinessAnalystReportModel> Get(string path)
        {
            var domain = await m_repository.Get(path);

            var model = m_mapper.Map(domain);
            return model;
        }
    }
}
