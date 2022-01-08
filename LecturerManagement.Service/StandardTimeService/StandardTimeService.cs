using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.StandardTime;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.StandardTimeService
{
    public class StandardTimeService : IStandardTimeService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public StandardTimeService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ServiceResponse<AddStandardTimeDto>> Create(AddStandardTimeDto createStandardTime)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<StandardTime>> Delete(StandardTime deleteStandardTime)
        {
            throw new NotImplementedException();
        }

        public Task<GetStandardTimeDto> Find(Expression<Func<StandardTime, bool>> expression = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<GetStandardTimeDto>> FindAll(Expression<Func<StandardTime, bool>> expression = null, Func<IQueryable<StandardTime>, IOrderedQueryable<StandardTime>> orderBy = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExisted(Expression<Func<StandardTime, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChange()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UpdateStandardTimeDto>> Update(UpdateStandardTimeDto updateStandardTime)
        {
            throw new NotImplementedException();
        }
    }
}
