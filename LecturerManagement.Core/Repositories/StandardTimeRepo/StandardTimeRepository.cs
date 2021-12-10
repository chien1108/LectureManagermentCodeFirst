using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.Core.Repositories.GenericRepo;

namespace LecturerManagement.Core.Repositories.StandardTimeRepo
{
    public class StandardTimeRepository : GenericRepository<StandardTime>, IStandardTimeRepository
    {
        private readonly LecturerManagementSystemDbContext _dbContext;

        public StandardTimeRepository(LecturerManagementSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
