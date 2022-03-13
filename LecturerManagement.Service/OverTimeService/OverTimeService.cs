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

        //public async Task<ServiceResponse<string>> GetAllLecturerResearchOfSingleLecturer(string lecturerId)
        //{
        //    //TODO: Lấy thông tin thời gian giảng dạy thực tế: Select theo năm bảng class
        //    var listClassGiangDay = await _unitOfWork.Teachings.FindAllAsync(expression: x => x.LectureId == lecturerId);
        //    foreach (var item in listClassGiangDay)
        //    {

        //    }
        //    //TODO: Lấy thông tin NCKH, năm cuối, năm 1,2,3
        //    //TODO: Lấy thông HDNCKH
        //    var listHDNCKH = await _unitOfWork.ScientificResearchGuides.FindAllAsync(expression: x => x.LecturerId == lecturerId);
        //    //TODO: Lấy Thông Tin về TTDN,
        //    //TODO: Lấy Thông tin về NCKH Cấp trường
        //    var listLecturerReserch = await _unitOfWork.LecturerScientificResearches.FindAllAsync(expression: x => x.LecturerId == lecturerId);
        //    //TODO: Lấy Thông tin về NCKH Cấp Bộ
        //    //TODO: lấy thông tin Đồ án tốt nghiệp
        //    var listDATN = await _unitOfWork.GraduationThesises.FindAllAsync(expression: x => x.LecturerId == lecturerId);
        //    //TODO: Lấy thông tin về quản lý phòng máy
        //    var lisQLPM = await _unitOfWork.MachineRooms.FindAllAsync(expression: x => x.LecturerId == lecturerId);
        //    //TODO: Lấy thông tin % số giờ được giảm với chức vụ tương đương
        //    var lecturer = await _unitOfWork.Lecturers.FindByConditionAsync(expression: x => x.Id == lecturerId);
        //    var discountPercent = lecturer.Position.DiscountPercent / 100;

        //    return null;
        //}


        public async Task<double> GetActualTeachingTimeInASemester(string lecturerId, string schoolYear)
        {
            //TODO: Get Danh Sách các lớp dạy => Môn học => Số tiết
            //var listTeachingActualOfLectuere = await _unitOfWork.Teachings.FindAllAsync(x => x.LectureId == lecturerId && x.SchoolYear == schoolYear);
            //int sumQuantityUnit = 0;
            //foreach (var item in listTeachingActualOfLectuere)
            //{
            //    sumQuantityUnit += item.Subject.QuantityUnit;
            //}

            var machineRoom = CalculateMachineRoomMangermentTime(lecturerId);
            var nameProjectAndGuidTheProject = CalculateNameProjectAndGuidTheProject(lecturerId);
            var nckhLevelTruong = CalculateLecturerResearchCapTruong(lecturerId, schoolYear);
            var nckhLevelBo = CalculateLecturerResearchCapBo(lecturerId, schoolYear);
            var hdnckhNamGancuoi = CalculateLecturerGuidResearchSV(lecturerId, schoolYear);
            var hdnckhNamCuoi = CalculateLecturerGuidResearchFinalYearStudent(lecturerId, schoolYear);
            var ttdn = CalculateInternsiveGuid(lecturerId, schoolYear);

            var listall = await Task.WhenAll(machineRoom, nameProjectAndGuidTheProject, nckhLevelBo, nckhLevelTruong, hdnckhNamCuoi, hdnckhNamGancuoi, ttdn);
            return machineRoom.Result + nameProjectAndGuidTheProject.Result + nckhLevelTruong.Result + nckhLevelBo.Result + hdnckhNamCuoi.Result + hdnckhNamGancuoi.Result + ttdn.Result;
        }


        #region Tính % chức vụ Table Posion
        public async Task<double> CalculateStandardTimeActual(string lecturerId)
        {
            //TODO: Get Position
            var lecturer = await _unitOfWork.Lecturers.FindByConditionAsync(x => x.Id == lecturerId);
            var positionOfLecturer = lecturer.Position.DiscountPercent;

            var standardTimeOfLecturer = lecturer.StandardTime.StandardHours;

            return (double)((positionOfLecturer * standardTimeOfLecturer) * 2 / 100);
            //TODO: Get StandardTime
        }
        #endregion

        #region Tính giờ Quản Lý Phòng Máy
        public async Task<double> CalculateMachineRoomMangermentTime(string lecturerId)
        {
            var machineRoom = await _unitOfWork.MachineRooms.FindByConditionAsync(x => x.LecturerId == lecturerId);

            return (machineRoom.QantityRoom * 40);
        }
        #endregion

        public async Task<double> CalculateNameProjectAndGuidTheProject(string lecturerId)
        {
            var listDoAn = await _unitOfWork.GraduationThesises.FindAllAsync(x => x.LecturerId == lecturerId);
            double sumOfTimeActual = 0;
            foreach (var item in listDoAn)
            {
                // Tính Giờ Ra đề và Hướng dẫn đồ án
                if (item.TopicNumbers != 0)
                {
                    sumOfTimeActual += (double)item.TopicNumbers * 12;
                }
                // Tính Giờ Chấm Đồ Án
                if (item.MarkSessionNumbers != 0)
                {
                    sumOfTimeActual += (double)item.MarkSessionNumbers * 2;
                }
                // Tính Giờ Phản biện đồ án
                if (item.RebuttalProjectNumbers != 0)
                {
                    sumOfTimeActual += (double)(item.RebuttalProjectNumbers * 2);
                }
            }
            return sumOfTimeActual;
        }


        #region tính giờ GV NCKH cấp trường
        public async Task<double> CalculateLecturerResearchCapTruong(string lecturerId, string namNC)
        {
            var listNCKHCapTruong = await _unitOfWork.LecturerScientificResearches.FindAllAsync(x => x.LecturerId == lecturerId && x.YearOfResearchParticipation == namNC && x.LevelOfResearch == DTOS.Modules.Enums.ScientificResearchLevel.Trường);
            double sumOfTimeActual = 0;
            foreach (var item in listNCKHCapTruong)
            {
                sumOfTimeActual += 60;
            }
            return sumOfTimeActual;
        }
        #endregion

        #region Tính giờ NCKH cấp bộ
        public async Task<double> CalculateLecturerResearchCapBo(string lecturerId, string namNC)
        {
            var listNCKHCapTruong = await _unitOfWork.LecturerScientificResearches.FindAllAsync(x => x.LecturerId == lecturerId && x.YearOfResearchParticipation == namNC && x.LevelOfResearch == DTOS.Modules.Enums.ScientificResearchLevel.Bộ);
            double sumOfTimeActual = 0;
            foreach (var item in listNCKHCapTruong)
            {
                sumOfTimeActual += 120;
            }
            return sumOfTimeActual;
        }
        #endregion

        #region HDNCKH năm gần cuối
        public async Task<double> CalculateLecturerGuidResearchSV(string lecturer, string yearSchool)
        {
            var listLecturerGuid = await _unitOfWork.ScientificResearchGuides.FindAllAsync(x => x.LecturerId == lecturer && x.SchoolYear == yearSchool && x.StudentYear != "Năm Cuối");
            var sumOfTimeActual = 0;
            foreach (var item in listLecturerGuid)
            {
                sumOfTimeActual += item.Quantity * 20;
            }
            return sumOfTimeActual;
        }
        #endregion

        #region HDNCKH năm cuối
        public async Task<double> CalculateLecturerGuidResearchFinalYearStudent(string lecturerId, string schoolYear)
        {
            var listLecturerGuid = await _unitOfWork.ScientificResearchGuides.FindAllAsync(x => x.LecturerId == lecturerId && x.SchoolYear == schoolYear && x.StudentYear == "Năm Cuối");
            var sumOfTimeActual = 0;
            foreach (var item in listLecturerGuid)
            {
                sumOfTimeActual += item.Quantity * 10;
            }
            return sumOfTimeActual;
        }
        #endregion

        #region TTDN
        public async Task<double> CalculateInternsiveGuid(string lecturerId, string schoolYear)
        {
            var teaching = await _unitOfWork.Teachings.FindAllAsync(x => x.LectureId == lecturerId && x.Subject.SubjectTypeId == "LM03" && x.SchoolYear == schoolYear);
            double sumOfTimeActual = 0;
            foreach (var item in teaching)
            {
                sumOfTimeActual += (double)item.Class.NumberOfStudent * 2;
            }
            return (double)sumOfTimeActual;
        }
        #endregion
    }
}
