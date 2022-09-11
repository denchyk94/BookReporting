using BookReporting.Application.Mappers.Contracts;
using BookReporting.Application.Models;
using BookReporting.Application.Services.Contracts;
using BookReporting.Domain.AggregateRoots;
using BookReporting.Infrastructure.Repositories.Contracts;
using System.Threading.Tasks;

namespace BookReporting.Application.Services
{
    /// <summary>
    /// Researcher service
    /// </summary
    public class ResearcherService : IResearcherService
    {
        private readonly IResearcherRepository<Researcher> m_repository;
        private readonly IMapper<Researcher, ResearcherReportModel> m_mapper;

        public ResearcherService(IResearcherRepository<Researcher> repository, IMapper<Researcher, ResearcherReportModel> mapper)
        {
            m_repository = repository;
            m_mapper = mapper;
        }

        public async Task<ResearcherReportModel> Get(string path)
        {
            var domain = await m_repository.Get(path);

            var model = m_mapper.Map(domain);
            return model;
        }
    }
}
