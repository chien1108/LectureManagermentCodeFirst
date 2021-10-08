using LecturerManagermentCodeFirst.API.Entities;
using LecturerManagermentCodeFirst.API.Services;
using LecturerManagermentCodeFirst.DTO.DTOS.Account;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Data
{
    public interface IAuthRepository
    {
        Task<ServiceResponse<string>> Register(AccountResgisterDto accountRegisterDto);
        Task<ServiceResponse<string>> Login(string username, string password);
    }
}