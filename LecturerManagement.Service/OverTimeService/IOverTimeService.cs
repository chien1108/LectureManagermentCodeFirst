using LecturerManagement.Core.Models;
using System.Threading.Tasks;

namespace LecturerManagement.Service.OverTimeService
{
    public interface IOverTimeService
    {
        //Task<ServiceResponse<string>> GetAllLecturerResearchOfSingleLecturer(string lecturerId);
        Task<double> GetActualTeachingTimeInASemester(string lecturerId, string schoolYear);
        Task<double> CalculateStandardTimeActual(string lecturerId);
        Task<double> CalculateMachineRoomMangermentTime(string lecturerId);
        Task<double> CalculateNameProjectAndGuidTheProject(string lecturerId);
        Task<double> CalculateLecturerResearchCapTruong(string lecturerId, string namNC);
        Task<double> CalculateLecturerResearchCapBo(string lecturerId, string namNC);
        Task<double> CalculateLecturerGuidResearchSV(string lecturer, string yearSchool);
        Task<double> CalculateLecturerGuidResearchFinalYearStudent(string lecturerId, string schoolYear);
    }
}