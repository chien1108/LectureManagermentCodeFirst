using AutoMapper;
using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.LecturerDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.LecturerService
{
    public class LecturerService : ILecturerService
    {

        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public LecturerService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public Task<ServiceResponse<AddLecturerDto>> Create(AddLecturerDto createLecturer)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<Lecturer>> Delete(Lecturer deleteLecturer)
        {
            throw new NotImplementedException();
        }

        public Task<GetLecturerDto> Find(Expression<Func<Lecturer, bool>> expression = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<GetLecturerDto>> FindAll(Expression<Func<Lecturer, bool>> expression = null, Func<IQueryable<Lecturer>, IOrderedQueryable<Lecturer>> orderBy = null, List<string> includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsExisted(Expression<Func<Lecturer, bool>> expression = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChange()
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<UpdateLecturerDto>> Update(UpdateLecturerDto updateLecturer)
        {
            throw new NotImplementedException();
        }
    }
}
