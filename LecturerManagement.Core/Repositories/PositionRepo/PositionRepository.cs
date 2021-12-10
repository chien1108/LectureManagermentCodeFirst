using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.Core.Repositories.GenericRepo;

namespace LecturerManagement.Core.Repositories.PositionRepo
{
    public class PositionRepository : GenericRepository<Position>, IPositionRepository
    {
        private readonly LecturerManagementSystemDbContext _dbContext;

        public PositionRepository(LecturerManagementSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
