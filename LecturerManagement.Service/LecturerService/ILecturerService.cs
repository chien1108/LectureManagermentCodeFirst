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
    public interface ILecturerService
    {
        //CRUD
        Task<ServiceResponse<AddLecturerDto>> Create(AddLecturerDto createLecturer);

        Task<ServiceResponse<Lecturer>> Delete(Lecturer deleteLecturer);
        Task<ServiceResponse<UpdateLecturerDto>> Update(UpdateLecturerDto updateLecturer);
        Task<bool> IsExisted(Expression<Func<Lecturer, bool>> expression = null);
        Task<ICollection<GetLecturerDto>> FindAll(Expression<Func<Lecturer,
                                bool>> expression = null,
                                Func<IQueryable<Lecturer>,
                               IOrderedQueryable<Lecturer>> orderBy = null,
                                List<string> includes = null);
        Task<GetLecturerDto> Find(Expression<Func<Lecturer, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}