using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.Core.Repositories.GenericRepo;

namespace LecturerManagement.Core.Repositories.SubjectRepo
{
    public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
    {
        private readonly LecturerManagementSystemDbContext _dbContext;

        public SubjectRepository(LecturerManagementSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
