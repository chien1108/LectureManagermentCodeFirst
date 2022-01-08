using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.ScientificResearchGuide;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.ScientificResearchGuideService
{
    public class ScientificResearchGuideService : IScientificResearchGuideService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ScientificResearchGuideService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ServiceResponse<AddScientificResearchGuideDto>> Create(AddScientificResearchGuideDto createScientificResearchGuide)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<ScientificResearchGuide>> Delete(ScientificResearchGuide deleteScientificResearchGuide)
        {
            throw new NotImplementedException();
        }

        public Task<GetScientificResearchGuideDto> Find(Expression<Func<ScientificResearchGuide, bool>> expression = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<GetScientificResearchGuideDto>> FindAll(Expression<Func<ScientificResearchGuide, bool>> expression = null, Func<IQueryable<ScientificResearchGuide>, IOrderedQueryable<ScientificResearchGuide>> orderBy = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExisted(Expression<Func<ScientificResearchGuide, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChange()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UpdateScientificResearchGuideDto>> Update(UpdateScientificResearchGuideDto updateScientificResearchGuide)
        {
            throw new NotImplementedException();
        }
    }
}
