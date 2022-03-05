﻿using LecturerManagement.Core.Models;
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
        Task<ServiceResponse<Tuple<string, string>>> Register(AccountResgisterDto accountRegisterDto);
        Task<ServiceResponse<string>> Login(string username, string password);
        Task<ServiceResponse<string>> ChangePassword(string username, string newPassword);

        //RUD
        Task<ServiceResponse<GetAccountDto>> GetAccountByUsername(string username);
        Task<ServiceResponse<GetAccountDto>> UpdateAccount(string username, UpdateAccountDto updateAccount);
        Task<ServiceResponse<string>> DeleteAccount(string username);

        ////Task<ServiceResponse<AddAdvancedLearningDto>> Create(AddAdvancedLearningDto createAdvancedLearning);

        Task<ServiceResponse<string>> Delete(Expression<Func<Account, bool>> expression = null);
        Task<ServiceResponse<UpdateAccountDto>> Update(UpdateAccountDto updateAccount, Expression<Func<Account, bool>> expression = null);
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