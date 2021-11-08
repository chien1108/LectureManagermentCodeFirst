using LecturerManagermentCodeFirst.DTO.DTOS.Account;
using LecturerManagermentCodeFirst.DTO.Enum;
using System;

namespace LecturerManagermentCodeFirst.DTO.DTOS.Lecturer
{
    public class GetLecturerDto
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string IdentityCardNumber { get; set; }
        public string Portrait { get; set; }
        public AcademicLevel AcademicLevel { get; set; }
        public string PositionID { get; set; }
        public string YearStartWork { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; } = null;
        public string AccountId { get; set; }
        public GetAccountDto Account { get; set; }
    }
}

