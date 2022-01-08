using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.TrainingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.TrainingSystemService
{
    public class TrainingSystemService : ITrainingSystemService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public TrainingSystemService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ServiceResponse<AddTrainingSystemDto>> Create(AddTrainingSystemDto createTrainingSystem)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<TrainingSystem>> Delete(TrainingSystem deleteTrainingSystem)
        {
            throw new NotImplementedException();
        }

        public Task<GetTrainingSystemDto> Find(Expression<Func<TrainingSystem, bool>> expression = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<GetTrainingSystemDto>> FindAll(Expression<Func<TrainingSystem, bool>> expression = null, Func<IQueryable<TrainingSystem>, IOrderedQueryable<TrainingSystem>> orderBy = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExisted(Expression<Func<TrainingSystem, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChange()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UpdateTrainingSystemDto>> Update(UpdateTrainingSystemDto updateTrainingSystem)
        {
            throw new NotImplementedException();
        }
    }
}
