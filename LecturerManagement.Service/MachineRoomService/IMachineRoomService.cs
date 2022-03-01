using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.MachineRoom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.MachineRoomService
{
    public interface IMachineRoomService
    {
        //CRUD
        Task<ServiceResponse<GetMachineRoomDto>> AddMachineRoom(AddMachineRoomDto createMachineRoom);

        Task<ServiceResponse<GetMachineRoomDto>> DeleteMachineRoom(MachineRoom deleteMachineRoom);
        Task<ServiceResponse<GetMachineRoomDto>> UpdateMachineRoom(UpdateMachineRoomDto updateMachineRoom, Expression<Func<MachineRoom, bool>> expression = null);
        Task<bool> IsExisted(Expression<Func<MachineRoom, bool>> expression = null);
        Task<ServiceResponse<ICollection<GetMachineRoomDto>>> GetAllMachineRoom(Expression<Func<MachineRoom,
                                bool>> expression = null,
                                Func<IQueryable<MachineRoom>,
                               IOrderedQueryable<MachineRoom>> orderBy = null,
                                List<string> includes = null);
        Task<ServiceResponse<GetMachineRoomDto>> GetMachineRoomByCondition(Expression<Func<MachineRoom, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}