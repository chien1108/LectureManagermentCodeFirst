using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.Core.Repositories.GenericRepo;

namespace LecturerManagement.Core.Repositories.SubjectTypeRepo
{
    public class SubjectTypeRepository : GenericRepository<SubjectType>, ISubjectTypeRepository
    {
        private readonly LecturerManagementSystemDbContext _dbContext;

        public SubjectTypeRepository(LecturerManagementSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
