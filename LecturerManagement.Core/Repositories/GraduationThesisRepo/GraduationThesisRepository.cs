using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.Core.Repositories.GenericRepo;

namespace LecturerManagement.Core.Repositories.GraduationThesisRepo
{
    public class GraduationThesisRepository : GenericRepository<GraduationThesis>, IGraduationThesisRepository
    {
        private readonly LecturerManagementSystemDbContext _dbContext;

        public GraduationThesisRepository(LecturerManagementSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
