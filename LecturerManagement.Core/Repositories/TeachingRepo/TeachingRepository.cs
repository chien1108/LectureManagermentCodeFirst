using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.Core.Repositories.GenericRepo;

namespace LecturerManagement.Core.Repositories.TeachingRepo
{
    public class TeachingRepository : GenericRepository<Teaching>, ITeachingRepository
    {
        private readonly LecturerManagementSystemDbContext _dbContext;

        public TeachingRepository(LecturerManagementSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
