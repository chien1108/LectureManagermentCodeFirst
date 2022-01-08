using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.GraduationThesis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.GraduationThesisService
{
    public class GraduationThesisService : IGraduationThesisService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public GraduationThesisService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ServiceResponse<AddGraduationThesisDto>> Create(AddGraduationThesisDto createGraduationThesis)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GraduationThesis>> Delete(GraduationThesis deleteGraduationThesis)
        {
            throw new NotImplementedException();
        }

        public Task<GetGraduationThesisDto> Find(Expression<Func<GraduationThesis, bool>> expression = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<GetGraduationThesisDto>> FindAll(Expression<Func<GraduationThesis, bool>> expression = null, Func<IQueryable<GraduationThesis>, IOrderedQueryable<GraduationThesis>> orderBy = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExisted(Expression<Func<GraduationThesis, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChange()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UpdateGraduationThesisDto>> Update(UpdateGraduationThesisDto updateGraduationThesis)
        {
            throw new NotImplementedException();
        }
    }
}
