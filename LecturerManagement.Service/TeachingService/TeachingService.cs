using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Teaching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.TeachingService
{
    public class TeachingService : ITeachingService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public TeachingService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ServiceResponse<AddTeachingDto>> Create(AddTeachingDto createTeaching)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Teaching>> Delete(Teaching deleteTeaching)
        {
            throw new NotImplementedException();
        }

        public Task<GetTeachingDto> Find(Expression<Func<Teaching, bool>> expression = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<GetTeachingDto>> FindAll(Expression<Func<Teaching, bool>> expression = null, Func<IQueryable<Teaching>, IOrderedQueryable<Teaching>> orderBy = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExisted(Expression<Func<Teaching, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChange()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UpdateTeachingDto>> Update(UpdateTeachingDto updateTeaching)
        {
            throw new NotImplementedException();
        }
    }
}
