using LecturerManagement.Core.Contracts;
using LecturerManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturerManagement.Service.OverTimeService
{
    public class OverTimeService : IOverTimeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OverTimeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<ServiceResponse<string>> GetAllLecturerResearchOfSingleLecturer(string lecturerId)
        {
            //TODO: Lấy thông tin thời gian giảng dạy thực tế: Select theo năm bảng class
            //TODO: Lấy thông tin NCKH, năm cuối, năm 1,2,3
            //TODO: Lấy thông HDNCKH
            //TODO: Lấy Thông Tin về TTDN,
            //TODO: Lấy Thông tin về NCKH Cấp trường
            //TODO: Lấy Thông tin về NCKH Cấp Bộ
            //TODO: lấy thông tin Đồ án tốt nghiệp
            //TODO: Lấy thông tin về quản lý phòng máy
            //TODO: Lấy thông tin % số giờ được giảm với chức vụ tương đương

            var listLecturerReserch = await _unitOfWork.LecturerScientificResearches.FindAllAsync(expression: x => x.LecturerId == lecturerId);
            return null;
        }
    }
}
