using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.LecturerScientificResearch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.LecturerScientificResearchService
{
    public class LecturerScientificResearchService : ILecturerScientificResearchService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public LecturerScientificResearchService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ServiceResponse<AddLecturerScientificResearchDto>> Create(AddLecturerScientificResearchDto createLecturerScientificResearch)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<LecturerScientificResearch>> Delete(LecturerScientificResearch deleteLecturerScientificResearch)
        {
            throw new NotImplementedException();
        }

        public Task<GetLecturerScientificResearchDto> Find(Expression<Func<LecturerScientificResearch, bool>> expression = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<GetLecturerScientificResearchDto>> FindAll(Expression<Func<LecturerScientificResearch, bool>> expression = null, Func<IQueryable<LecturerScientificResearch>, IOrderedQueryable<LecturerScientificResearch>> orderBy = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExisted(Expression<Func<LecturerScientificResearch, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChange()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UpdateLecturerScientificResearchDto>> Update(UpdateLecturerScientificResearchDto updateLecturerScientificResearch)
        {
            throw new NotImplementedException();
        }
    }
}
