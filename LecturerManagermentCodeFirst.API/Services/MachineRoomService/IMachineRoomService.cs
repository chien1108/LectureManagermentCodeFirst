using LecturerManagermentCodeFirst.DTO.DTOS.MachineRoom;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Services.MachineRoomService
{
    public interface IMachineRoomService
    {
        Task<ServiceResponse<GetMachineRoomDto>> GetMachineRoomById(int id);
        Task<ServiceResponse<IEnumerable<GetMachineRoomDto>>> GetMachineRooms();
        Task<ServiceResponse<IEnumerable<GetMachineRoomDto>>> AddMachineRoom(AddMachineRoomDto add);
        Task<ServiceResponse<GetMachineRoomDto>> UpdateMachineRoom(UpdateMachineRoomDto update);
        Task<ServiceResponse<IEnumerable<GetMachineRoomDto>>> DeleteMachineRoom(int id);
    }
}