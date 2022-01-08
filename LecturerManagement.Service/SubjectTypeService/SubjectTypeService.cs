using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.SubjectType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.SubjectTypeService
{
    public class SubjectTypeService : ISubjectTypeService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SubjectTypeService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ServiceResponse<AddSubjectTypeDto>> Create(AddSubjectTypeDto createSubjectType)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<SubjectType>> Delete(SubjectType deleteSubjectType)
        {
            throw new NotImplementedException();
        }

        public Task<GetSubjectTypeDto> Find(Expression<Func<SubjectType, bool>> expression = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<GetSubjectTypeDto>> FindAll(Expression<Func<SubjectType, bool>> expression = null, Func<IQueryable<SubjectType>, IOrderedQueryable<SubjectType>> orderBy = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExisted(Expression<Func<SubjectType, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChange()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UpdateSubjectTypeDto>> Update(UpdateSubjectTypeDto updateSubjectType)
        {
            throw new NotImplementedException();
        }
    }
}
