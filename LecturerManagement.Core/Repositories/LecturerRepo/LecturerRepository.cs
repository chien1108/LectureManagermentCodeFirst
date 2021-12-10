using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.Core.Repositories.GenericRepo;

namespace LecturerManagement.Core.Repositories.LecturerRepo
{
    public class LecturerRepository : GenericRepository<Lecturer>, ILecturerRepository
    {
        private readonly LecturerManagementSystemDbContext _dbContext;

        public LecturerRepository(LecturerManagementSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
