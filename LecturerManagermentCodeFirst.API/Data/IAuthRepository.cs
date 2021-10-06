using LecturerManagermentCodeFirst.API.Entities;
using LecturerManagermentCodeFirst.API.Services;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<int>> Register(Account user, string password);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<bool> UserExists(string username);
    }
}