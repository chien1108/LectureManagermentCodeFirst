using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.Core.Repositories.GenericRepo;

namespace LecturerManagement.Core.Repositories.SubjectDepartmentRepo
{
    public class SubjectDepartmentRepository : GenericRepository<SubjectDepartment>, ISubjectDepartmentRepository
    {
        private readonly LecturerManagementSystemDbContext _dbContext;

        public SubjectDepartmentRepository(LecturerManagementSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
