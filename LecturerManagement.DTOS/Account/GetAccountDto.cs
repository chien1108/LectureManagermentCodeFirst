using LecturerManagement.Core.Modules.Enums;
using LecturerManagement.DTOS.LecturerDTO;
using System;

namespace LecturerManagement.DTOS.Account
{
    public class GetAccountDto
    {
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public Permission Permission { get; set; }
        public DateTime? DateCreated { get; set; }
        public GetLecturerScientificResearchDto Lecturer { get; set; }

    }
}
