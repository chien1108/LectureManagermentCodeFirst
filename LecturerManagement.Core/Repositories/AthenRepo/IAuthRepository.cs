using LecturerManagement.Core.Models;
using System.Threading.Tasks;

namespace LecturerManagement.Core.Repositories.AuthenRepo
{
    public interface IAuthRepository
    {
        //Task<ServiceResponse<string>> Register(AccountResgisterDto accountRegisterDto);
        Task<ServiceResponse<string>> Login(string username, string password);
    }
}