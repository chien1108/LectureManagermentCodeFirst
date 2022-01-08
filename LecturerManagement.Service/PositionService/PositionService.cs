using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Position;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.PositionService
{
    public class PositionService : IPositionService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public PositionService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public Task<ServiceResponse<AddPositionDto>> Create(AddPositionDto createPosition)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Position>> Delete(Position deletePosition)
        {
            throw new NotImplementedException();
        }

        public Task<GetPositionDto> Find(Expression<Func<Position, bool>> expression = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<GetPositionDto>> FindAll(Expression<Func<Position, bool>> expression = null, Func<IQueryable<Position>, IOrderedQueryable<Position>> orderBy = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExisted(Expression<Func<Position, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChange()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UpdatePositionDto>> Update(UpdatePositionDto updatePosition)
        {
            throw new NotImplementedException();
        }
    }
}
