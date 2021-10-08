using LecturerManagermentCodeFirst.DTO.DTOS.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Services.AccountService
{
    public class AccountService : IAccountService
    {
        public Task<ServiceResponse<string>> DeleteAccount(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetAccountDto>> GetAccountByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResponse<GetAccountDto>> UpdateAccount(UpdateAccountDto updateAccount)
        {
            throw new NotImplementedException();
        }
    }
}
