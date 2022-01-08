using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Subject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.SubjectService
{
    public class SubjectService : ISubjectService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public SubjectService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ServiceResponse<AddSubjectDto>> Create(AddSubjectDto createSubject)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Subject>> Delete(Subject deleteSubject)
        {
            throw new NotImplementedException();
        }

        public Task<GetSubjectDto> Find(Expression<Func<Subject, bool>> expression = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<GetSubjectDto>> FindAll(Expression<Func<Subject, bool>> expression = null, Func<IQueryable<Subject>, IOrderedQueryable<Subject>> orderBy = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExisted(Expression<Func<Subject, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChange()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UpdateSubjectDto>> Update(UpdateSubjectDto updateSubject)
        {
            throw new NotImplementedException();
        }
    }
}
