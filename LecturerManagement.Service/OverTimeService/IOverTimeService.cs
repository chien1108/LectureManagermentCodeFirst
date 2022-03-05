using LecturerManagement.Core.Models;
using System.Threading.Tasks;

namespace LecturerManagement.Service.OverTimeService
{
    public interface IOverTimeService
    {
        Task<ServiceResponse<string>> GetAllLecturerResearchOfSingleLecturer(string lecturerId);
    }
}