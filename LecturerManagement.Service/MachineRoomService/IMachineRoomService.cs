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
        Task<ServiceResponse<AddMachineRoomDto>> Create(AddMachineRoomDto createMachineRoom);

        Task<ServiceResponse<MachineRoom>> Delete(MachineRoom deleteMachineRoom);
        Task<ServiceResponse<UpdateMachineRoomDto>> Update(UpdateMachineRoomDto updateMachineRoom);
        Task<bool> IsExisted(Expression<Func<MachineRoom, bool>> expression = null);
        Task<ICollection<GetMachineRoomDto>> FindAll(Expression<Func<MachineRoom,
                                bool>> expression = null,
                                Func<IQueryable<MachineRoom>,
                               IOrderedQueryable<MachineRoom>> orderBy = null,
                                List<string> includes = null);
        Task<GetMachineRoomDto> Find(Expression<Func<MachineRoom, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}