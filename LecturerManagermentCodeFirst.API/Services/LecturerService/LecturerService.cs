using AutoMapper;
using LecturerManagermentCodeFirst.API.Data;
using LecturerManagermentCodeFirst.API.Entities;
using LecturerManagermentCodeFirst.DTO.DTOS.Lecturer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Services.LecturerService
{
    public class LecturerService : ILecturerService
    {
        private readonly LecturerManagermentSystemDbContext _context;
        private readonly IMapper _mapper;

        public LecturerService(LecturerManagermentSystemDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<IEnumerable<GetLecturerDto>>> AddLecturer(AddLecturerDto add)
        {
            var response = new ServiceResponse<IEnumerable<GetLecturerDto>>();
            try
            {
                var lecturer = _mapper.Map<Lecturer>(add);
                _context.Lecturers.Add(lecturer);
                await _context.SaveChangesAsync();
                response.Data = _context.Lecturers.Select(x => _mapper.Map<GetLecturerDto>(x));
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<IEnumerable<GetLecturerDto>>> DeleteLecturer(int id)
        {
            var response = new ServiceResponse<IEnumerable<GetLecturerDto>>();
            try
            {
                var lecturer = await _context.Lecturers.FirstOrDefaultAsync(x => x.ID.Equals(id));
                _context.Lecturers.Remove(lecturer);
                await _context.SaveChangesAsync();
                response.Data = _context.Lecturers.Select(x => _mapper.Map<GetLecturerDto>(x));
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetLecturerDto>> GetLecturerById(int id)
        {
            var response = new ServiceResponse<GetLecturerDto>();
            try
            {
                response.Data = _mapper.Map<GetLecturerDto>(await _context.Lecturers.FirstOrDefaultAsync(x => x.ID.Equals(id)));
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<List<GetLecturerDto>>> GetLecturers()
        {
            var response = new ServiceResponse<List<GetLecturerDto>>();
            try
            {
                response.Data = await _context.Lecturers.Select(x => _mapper.Map<GetLecturerDto>(x)).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }

        public async Task<ServiceResponse<GetLecturerDto>> UpdateLecturer(UpdateLecturerDto update)
        {
            var response = new ServiceResponse<GetLecturerDto>();
            try
            {
                var lecturer = _mapper.Map<Lecturer>(update);
                _context.Lecturers.Update(lecturer);
                await _context.SaveChangesAsync();
                response.Data = _mapper.Map<GetLecturerDto>(lecturer);
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
