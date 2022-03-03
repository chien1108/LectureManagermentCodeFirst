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
        Task<ServiceResponse<GetLecturerDto>> AddLecturer(AddLecturerDto createLecturer);

        Task<ServiceResponse<GetLecturerDto>> DeleteLecturer(Expression<Func<Lecturer, bool>> expression = null);
        Task<ServiceResponse<GetLecturerDto>> UpdateLecturer(UpdateLecturerDto updateLecturer, Expression<Func<Lecturer, bool>> expression = null);
        Task<bool> IsExisted(Expression<Func<Lecturer, bool>> expression = null);
        Task<ServiceResponse<ICollection<GetLecturerDto>>> GetAllLecturer(Expression<Func<Lecturer,
                                bool>> expression = null,
                                Func<IQueryable<Lecturer>,
                               IOrderedQueryable<Lecturer>> orderBy = null,
                                List<string> includes = null);
        Task<ServiceResponse<GetLecturerDto>> GetLecturerByCondition(Expression<Func<Lecturer, bool>> expression = null, List<string> includes = null);
        Task<ServiceResponse<GetLecturerDto>> SetStandardTimeToLecturer(string standardTimeId, Expression<Func<Lecturer, bool>> expression = null);
        Task<ServiceResponse<GetLecturerDto>> SetSubjectDepartmentToLecturer(string subjectDepartmentId, Expression<Func<Lecturer, bool>> expression = null);
        Task<bool> SaveChange();
    }
}