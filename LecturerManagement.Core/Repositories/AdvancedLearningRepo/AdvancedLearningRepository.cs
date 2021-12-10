using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.Core.Repositories.GenericRepo;

namespace LecturerManagement.Core.Repositories.AdvancedLearningRepo
{
    public class AdvancedLearningRepository : GenericRepository<AdvancedLearning>, IAdvancedLearningRepository
    {
        private readonly LecturerManagementSystemDbContext _dbContext;

        public AdvancedLearningRepository(LecturerManagementSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
