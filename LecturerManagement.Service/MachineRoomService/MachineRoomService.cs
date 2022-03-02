using AutoMapper;
using LecturerManagement.Core.Contracts;
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
    public class MachineRoomService : IMachineRoomService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public MachineRoomService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<GetMachineRoomDto>> AddMachineRoom(AddMachineRoomDto createMachineRoom)
        {
            try
            {
                await _unitOfWork.MachineRooms.Create(_mapper.Map<MachineRoom>(createMachineRoom));
                if (await SaveChange())
                {
                    return new ServiceResponse<GetMachineRoomDto> { Success = true, Message = "Add Machine Room Success" };
                }
                else
                {
                    return new ServiceResponse<GetMachineRoomDto> { Success = false, Message = "Error when create new Machine Room" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetMachineRoomDto> { Success = false, Message = ex.Message };
            }
        }
        public async Task<ServiceResponse<GetMachineRoomDto>> DeleteMachineRoom(Expression<Func<MachineRoom, bool>> expression = null)
        {
            try
            {
                var machineRoomFromDb = await _unitOfWork.MachineRooms.FindByConditionAsync(expression);
                _unitOfWork.MachineRooms.Delete(machineRoomFromDb);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetMachineRoomDto> { Success = false, Message = "Error when delete Machine Room" };
                }
                return new ServiceResponse<GetMachineRoomDto> { Success = true, Message = "Delete Machine Room Success" };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetMachineRoomDto> { Success = false, Message = ex.Message };
            }
        }


        public async Task<ServiceResponse<ICollection<GetMachineRoomDto>>> GetAllMachineRoom(Expression<Func<MachineRoom, bool>> expression = null, Func<IQueryable<MachineRoom>, IOrderedQueryable<MachineRoom>> orderBy = null, List<string> includes = null)
        {
            var listMachineRoomFromDB = _mapper.Map<ICollection<GetMachineRoomDto>>(await _unitOfWork.MachineRooms.FindAllAsync(expression, orderBy, includes));
            if (listMachineRoomFromDB != null)
            {
                return new() { Success = true, Message = "Get list Machine Room Success", Data = listMachineRoomFromDB };
            }
            return new() { Message = "List Machine Room is not exist", Success = false };
        }

        public async Task<ServiceResponse<GetMachineRoomDto>> GetMachineRoomByCondition(Expression<Func<MachineRoom, bool>> expression = null, List<string> includes = null)
        {
            var machineRoomFromDB = _mapper.Map<GetMachineRoomDto>(await _unitOfWork.MachineRooms.FindByConditionAsync(expression, includes));
            if (machineRoomFromDB != null)
            {
                return new() { Success = true, Message = "Get Machine Room Success", Data = machineRoomFromDB };
            }
            return new() { Message = "Machine Room is not exist", Success = false };
        }

        public async Task<bool> IsExisted(Expression<Func<MachineRoom, bool>> expression = null)
        {
            var isExist = await _unitOfWork.MachineRooms.FindByConditionAsync(expression);
            if (isExist == null)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> SaveChange()
        => await _unitOfWork.MachineRooms.Save();

        public async Task<ServiceResponse<GetMachineRoomDto>> UpdateMachineRoom(UpdateMachineRoomDto updateMachineRoom, Expression<Func<MachineRoom, bool>> expression = null)
        {
            try
            {
                var machineRoomFromDb = await _unitOfWork.MachineRooms.FindByConditionAsync(expression);

                machineRoomFromDb.ModifiedDate = DateTime.Now;
                machineRoomFromDb.Description = updateMachineRoom.Description;
                machineRoomFromDb.QantityRoom = updateMachineRoom.QantityRoom;
                machineRoomFromDb.SchoolYear = updateMachineRoom.SchoolYear;
                machineRoomFromDb.LecturerId = updateMachineRoom.LecturerID;
                _unitOfWork.MachineRooms.Update(machineRoomFromDb);
                if (!await SaveChange())
                {
                    return new ServiceResponse<GetMachineRoomDto> { Success = false, Message = "Error when update Machine Room" };
                }
                return new ServiceResponse<GetMachineRoomDto> { Success = true, Message = "Update Machine Room Success" };

            }
            catch (Exception ex)
            {
                return new ServiceResponse<GetMachineRoomDto> { Success = false, Message = ex.Message };
            }
        }
    }
}
