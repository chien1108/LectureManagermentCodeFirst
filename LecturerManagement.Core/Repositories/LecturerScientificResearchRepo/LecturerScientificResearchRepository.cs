using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.Core.Repositories.GenericRepo;

namespace LecturerManagement.Core.Repositories.LecturerScientificResearchRepo
{
    public class LecturerScientificResearchRepository : GenericRepository<LecturerScientificResearch>, ILecturerScientificResearchRepository
    {
        private readonly LecturerManagementSystemDbContext _dbContext;

        public LecturerScientificResearchRepository(LecturerManagementSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
