using LecturerManagement.DTOS.Models.Base;
using LecturerManagement.DTOS.Modules.Enums;
using System;

namespace LecturerManagement.DTOS.Account
{
    public class UpdateAccountDto : BaseEntity<int>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Permission Permission { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        ///public Status Status { get; set; }
        public DateTime? BirthDate { get; set; }
        public string IdentityCardNumber { get; set; }
        public string Portrait { get; set; }
        public AcademicLevel AcademicLevel { get; set; }
        public string YearStartWork { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; } = null;
        public DateTime? DateCreated { get; set; }
    }
}
