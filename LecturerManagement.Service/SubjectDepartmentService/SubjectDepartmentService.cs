using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.SubjectDepartment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.SubjectDepartmentService
{
    public class SubjectDepartmentService : ISubjectDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SubjectDepartmentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ServiceResponse<AddSubjectDepartmentDto>> Create(AddSubjectDepartmentDto createSubjectDepartment)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<SubjectDepartment>> Delete(SubjectDepartment deleteSubjectDepartment)
        {
            throw new NotImplementedException();
        }

        public Task<GetSubjectDepartmentDto> Find(Expression<Func<SubjectDepartment, bool>> expression = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<GetSubjectDepartmentDto>> FindAll(Expression<Func<SubjectDepartment, bool>> expression = null, Func<IQueryable<SubjectDepartment>, IOrderedQueryable<SubjectDepartment>> orderBy = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExisted(Expression<Func<SubjectDepartment, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChange()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UpdateSubjectDepartmentDto>> Update(UpdateSubjectDepartmentDto updateSubjectDepartment)
        {
            throw new NotImplementedException();
        }
    }
}
