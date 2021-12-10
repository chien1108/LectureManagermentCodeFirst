using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.Core.Repositories.GenericRepo;

namespace LecturerManagement.Core.Repositories.DynamicClassFactorRepo
{
    public class DynamicClassFactorRepository : GenericRepository<DynamicClassFactor>, IDynamicClassFactorRepository
    {
        private readonly LecturerManagementSystemDbContext _dbContext;

        public DynamicClassFactorRepository(LecturerManagementSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
