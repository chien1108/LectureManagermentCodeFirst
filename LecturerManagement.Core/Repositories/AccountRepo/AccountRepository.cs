using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.Core.Repositories.GenericRepo;

namespace LecturerManagement.Core.Repositories.AccountRepo
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly LecturerManagementSystemDbContext _dbContext;

        public AccountRepository(LecturerManagementSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
