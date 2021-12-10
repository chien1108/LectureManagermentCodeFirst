using LecturerManagement.Core.Data;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.Core.Repositories.GenericRepo;

namespace LecturerManagement.Core.Repositories.MachineRoomRepo
{
    public class MachineRoomRepository : GenericRepository<MachineRoom>, IMachineRoomRepository
    {
        private readonly LecturerManagementSystemDbContext _dbContext;

        public MachineRoomRepository(LecturerManagementSystemDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
