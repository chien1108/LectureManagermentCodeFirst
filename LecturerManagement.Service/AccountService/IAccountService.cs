using LecturerManagement.Core.Models;
using LecturerManagement.DTOS.Account;
using System.Threading.Tasks;

namespace LecturerManagement.Services.AccountService
{
    public interface IAccountService
    {

        //RUD
        Task<ServiceResponse<GetAccountDto>> GetAccountByUsername(string username);
        Task<ServiceResponse<GetAccountDto>> UpdateAccount(UpdateAccountDto updateAccount);
        Task<ServiceResponse<string>> DeleteAccount(string username);
    }
}