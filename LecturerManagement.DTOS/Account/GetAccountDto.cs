using LecturerManagement.DTOS.LecturerDTO;
using LecturerManagement.DTOS.Models.Base;
using LecturerManagement.DTOS.Modules.Enums;
using System;

namespace LecturerManagement.DTOS.Account
{
    public class GetAccountDto : BaseEntity<string>
    {
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public Permission Permission { get; set; }
        public DateTime? DateCreated { get; set; }
        public GetLecturerDto Lecturer { get; set; }
    }
}
