using LecturerManagement.DTOS.Modules.Enums;
using System;

namespace LecturerManagement.DTOS.Account
{
    public class AccountResgisterDto
    {
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string IdentityCardNumber { get; set; }
        public string Permission { get; set; }
        public byte[] Portrait { get; set; }
        public AcademicLevel AcademicLevel { get; set; }
        public string YearStartWork { get; set; }
        ///public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; } = null;
    }
}