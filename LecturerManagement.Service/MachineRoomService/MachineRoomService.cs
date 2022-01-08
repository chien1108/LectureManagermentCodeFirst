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

        public Task<ServiceResponse<AddMachineRoomDto>> Create(AddMachineRoomDto createMachineRoom)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<MachineRoom>> Delete(MachineRoom deleteMachineRoom)
        {
            throw new NotImplementedException();
        }

        public Task<GetMachineRoomDto> Find(Expression<Func<MachineRoom, bool>> expression = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<GetMachineRoomDto>> FindAll(Expression<Func<MachineRoom, bool>> expression = null, Func<IQueryable<MachineRoom>, IOrderedQueryable<MachineRoom>> orderBy = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExisted(Expression<Func<MachineRoom, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChange()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UpdateMachineRoomDto>> Update(UpdateMachineRoomDto updateMachineRoom)
        {
            throw new NotImplementedException();
        }
    }
}
