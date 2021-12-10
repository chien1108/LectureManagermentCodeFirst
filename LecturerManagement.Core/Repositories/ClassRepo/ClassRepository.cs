using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.Core.Repositories.GenericRepo;

namespace LecturerManagement.Core.Repositories.ClassRepo
{
    public class ClassRepository : GenericRepository<Class>, IClassRepository
    {
        private readonly LecturerManagementSystemDbContext _dbContext;

        public ClassRepository(LecturerManagementSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
