using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.Core.Repositories.GenericRepo;

namespace LecturerManagement.Core.Repositories.ScientificResearchGuideRepo
{
    public class ScientificResearchGuideRepository : GenericRepository<ScientificResearchGuide>, IScientificResearchGuideRepository
    {
        private readonly LecturerManagementSystemDbContext _dbContext;

        public ScientificResearchGuideRepository(LecturerManagementSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
