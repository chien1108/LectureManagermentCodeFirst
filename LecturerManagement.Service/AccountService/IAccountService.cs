using LecturerManagement.Core.Models;
using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace LecturerManagement.Services.AccountService
{
    public interface IAccountService
    {

        //RUD
        Task<ServiceResponse<GetAccountDto>> GetAccountByUsername(string username);
        Task<ServiceResponse<GetAccountDto>> UpdateAccount(string username, UpdateAccountDto updateAccount);
        Task<ServiceResponse<string>> DeleteAccount(string username);

        ////Task<ServiceResponse<AddAdvancedLearningDto>> Create(AddAdvancedLearningDto createAdvancedLearning);

        Task<ServiceResponse<string>> Delete(string userName);
        Task<ServiceResponse<UpdateAccountDto>> Update(UpdateAccountDto updateAccount);
        Task<bool> IsExisted(Expression<Func<Account, bool>> expression = null);
        Task<ICollection<GetAccountDto>> FindAll(Expression<Func<Account,
                                bool>> expression = null,
                                Func<IQueryable<Account>,
                               IOrderedQueryable<Account>> orderBy = null,
                                List<string> includes = null);
        Task<GetAccountDto> Find(Expression<Func<Account, bool>> expression = null, List<string> includes = null);
        Task<bool> SaveChange();
    }
}