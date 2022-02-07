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

        public async Task<ServiceResponse<AddMachineRoomDto>> Create(AddMachineRoomDto createMachineRoom)
        {
            try
            {
                await _unitOfWork.MachineRooms.Create(_mapper.Map<MachineRoom>(createMachineRoom));
                if (await SaveChange())
                {
                    return new ServiceResponse<AddMachineRoomDto> { Success = true, Message = "Add Machine Room Success" };
                }
                else
                {
                    return new ServiceResponse<AddMachineRoomDto> { Success = false, Message = "Error when create new Machine Room" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<AddMachineRoomDto> { Success = false, Message = ex.Message };
            }
        }

        public async Task<ServiceResponse<MachineRoom>> Delete(MachineRoom deleteMachineRoom)
        {
            try
            {
                var machineRoomFromDB = await Find(x => x.Id == 1.ToString());
                if (machineRoomFromDB != null)
                {
                    _unitOfWork.MachineRooms.Delete(deleteMachineRoom);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<MachineRoom> { Success = false, Message = "Error when delete Machine Room" };
                    }
                    return new ServiceResponse<MachineRoom> { Success = true, Message = "Delete Machine Room Success" };
                }
                else
                {
                    return new ServiceResponse<MachineRoom> { Success = false, Message = "Not Found Machine Room" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<MachineRoom> { Success = false, Message = ex.Message };
            }
        }

        public async Task<GetMachineRoomDto> Find(Expression<Func<MachineRoom, bool>> expression = null, List<string> includes = null)
        => _mapper.Map<GetMachineRoomDto>(await _unitOfWork.MachineRooms.FindByConditionAsync(expression, includes));

        public async Task<ICollection<GetMachineRoomDto>> FindAll(Expression<Func<MachineRoom, bool>> expression = null, Func<IQueryable<MachineRoom>, IOrderedQueryable<MachineRoom>> orderBy = null, List<string> includes = null)
          => _mapper.Map<ICollection<GetMachineRoomDto>>(await _unitOfWork.MachineRooms.FindAllAsync(expression, orderBy, includes));

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

        public async Task<ServiceResponse<UpdateMachineRoomDto>> Update(UpdateMachineRoomDto updateMachineRoom)
        {
            try
            {
                var machineRoomFromDB = await Find(x => x.Id == 1.ToString());
                if (machineRoomFromDB != null)
                {
                    var task = _mapper.Map<MachineRoom>(updateMachineRoom);
                    _unitOfWork.MachineRooms.Update(task);
                    if (!await SaveChange())
                    {
                        return new ServiceResponse<UpdateMachineRoomDto> { Success = false, Message = "Error when update Machine Room" };
                    }
                    return new ServiceResponse<UpdateMachineRoomDto> { Success = true, Message = "Update Machine Room Success" };
                }
                else
                {
                    return new ServiceResponse<UpdateMachineRoomDto> { Success = false, Message = "Not Found Machine Room" };
                }
            }
            catch (Exception ex)
            {
                return new ServiceResponse<UpdateMachineRoomDto> { Success = false, Message = ex.Message };
            }
        }
    }
}
