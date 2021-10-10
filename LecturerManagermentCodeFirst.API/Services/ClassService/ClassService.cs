using AutoMapper;
using LecturerManagermentCodeFirst.API.Data;
using LecturerManagermentCodeFirst.API.Entities;
using LecturerManagermentCodeFirst.DTO.DTOS.Class;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Services.ClassService
{
    public class ClassService : IClassService
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly IMapper _mapper;
        private readonly LecturerManagermentSystemDbContext _context;

        public ClassService(IHttpContextAccessor httpContext, IMapper mapper, LecturerManagermentSystemDbContext context)
        {
            _httpContext = httpContext;
            _mapper = mapper;
            _context = context;
        }
        public async Task<ServiceResponse<List<GetClassDto>>> AddClass(AddClassDto addClass)
        {
            var response = new ServiceResponse<List<GetClassDto>>();
            try
            {
                var classs = _mapper.Map<Class>(addClass);
                _context.Classes.Add(classs);
                await _context.SaveChangesAsync();
                response.Data = _context.Classes.Include(x => x.TrainingSystem).Select(x => _mapper.Map<GetClassDto>(x)).ToList();
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetClassDto>>> DeleteClass(string Id)
        {
            var response = new ServiceResponse<List<GetClassDto>>();
            try
            {
                var classs = await _context.Classes.FirstOrDefaultAsync(x => x.ID.ToLower().Equals(Id.ToLower()));
                if(classs == null)
                {
                    response.Success = false;
                    response.Message = "there is no class";
                    return response;
                }    
                _context.Classes.Remove(classs);
                await _context.SaveChangesAsync();
                response.Data = await _context.Classes.Include(x => x.TrainingSystem).Select(x => _mapper.Map<GetClassDto>(x)).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetClassDto>> GetClassById(string Id)
        {
            var response = new ServiceResponse<GetClassDto>();
            try
            {
                var classs = await _context.Classes.FirstOrDefaultAsync(x => x.ID.ToLower().Equals(Id.ToLower()));
                if (classs == null)
                {
                    response.Success = false;
                    response.Message = "there is no class";
                    return response;
                }
                response.Data = _mapper.Map<GetClassDto>(classs);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetClassDto>>> GetClasses()
        {
            var response = new ServiceResponse<List<GetClassDto>>();
            try
            {
                var classes = await _context.Classes.Include(x => x.TrainingSystem).Select(x => _mapper.Map<GetClassDto>(x)).ToListAsync();
                if (classes == null)
                {
                    response.Success = false;
                    response.Message = "there is no class";
                    return response;
                }
                response.Data = classes;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetClassDto>> UpdateClass(UpdateClassDto updateClass)
        {
            var response = new ServiceResponse<GetClassDto>();
            try
            {
                var classs = await _context.Classes.Include(x => x.TrainingSystem).FirstOrDefaultAsync(x => x.ID.Equals(updateClass.ID));
                if (classs == null)
                {
                    response.Success = false;
                    response.Message = "there is no class";
                    return response;
                }
                classs.Description = updateClass.Description;
                classs.FormsOfTraining = updateClass.FormsOfTraining;
                classs.Name = updateClass.Name;
                classs.NumberOfStudent = updateClass.NumberOfStudent;
                classs.TrainingSystemID = updateClass.TrainingSystemID;

                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetClassDto>(classs);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        private string GetUserId() => _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        private string GetUserRole() => _httpContext.HttpContext.User.FindFirstValue(ClaimTypes.Role);
    }
}
