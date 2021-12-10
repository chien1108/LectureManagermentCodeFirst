using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.Core.Repositories.GenericRepo;

namespace LecturerManagement.Core.Repositories.TrainingSystemRepo
{
    public class TrainingSystemRepository : GenericRepository<TrainingSystem>, ITrainingSystemRepository
    {
        private readonly LecturerManagementSystemDbContext _dbContext;

        public TrainingSystemRepository(LecturerManagementSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
