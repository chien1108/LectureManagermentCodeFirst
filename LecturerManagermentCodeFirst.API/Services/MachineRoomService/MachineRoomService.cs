using AutoMapper;
using LecturerManagermentCodeFirst.API.Data;
using LecturerManagermentCodeFirst.API.Entities;
using LecturerManagermentCodeFirst.DTO.DTOS.MachineRoom;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Services.MachineRoomService
{
    public class MachineRoomService : IMachineRoomService
    {
        private readonly LecturerManagermentSystemDbContext _context;
        private readonly IMapper _mapper;

        public MachineRoomService(LecturerManagermentSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<IEnumerable<GetMachineRoomDto>>> AddMachineRoom(AddMachineRoomDto add)
        {
            var response = new ServiceResponse<IEnumerable<GetMachineRoomDto>>();
            try
            {
                var machineRoom = _mapper.Map<MachineRoom>(add);
                _context.MachineRooms.Add(machineRoom);
                await _context.SaveChangesAsync();
                response.Data = _context.MachineRooms.Select(x => _mapper.Map<GetMachineRoomDto>(x));
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetMachineRoomDto>>> DeleteMachineRoom(int id)
        {
            var response = new ServiceResponse<IEnumerable<GetMachineRoomDto>>();
            try
            {
                var machineRoom = await _context.MachineRooms.FirstOrDefaultAsync(x => x.ID == id);
                _context.MachineRooms.Remove(machineRoom);
                await _context.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetMachineRoomDto>> GetMachineRoomById(int id)
        {
            var response = new ServiceResponse<GetMachineRoomDto>();
            try
            {
                var machineRoom = await _context.MachineRooms.FirstOrDefaultAsync(x => x.ID.Equals(id));
                response.Data = _mapper.Map<GetMachineRoomDto>(machineRoom);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetMachineRoomDto>>> GetMachineRooms()
        {
            var response = new ServiceResponse<IEnumerable<GetMachineRoomDto>>();
            try
            {
                response.Data = await _context.MachineRooms.Select(x => _mapper.Map<GetMachineRoomDto>(x)).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public Task<ServiceResponse<GetMachineRoomDto>> UpdateMachineRoom(UpdateMachineRoomDto update)
        {
            throw new NotImplementedException();
        }
    }
}
