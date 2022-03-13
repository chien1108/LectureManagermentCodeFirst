using LecturerManagement.DTOS.Modules.Enums;
using System;

namespace LecturerManagement.DTOS.LecturerDTO
{
    public class UpdateLecturerDto
    {
        public string StandardTimeID { get; set; }

        public string SubjectDepartmentID { get; set; }
        ////public Status Status { get; set; }
        public string FullName { get; set; }
        public Gender Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string IdentityCardNumber { get; set; }
        public byte[] Portrait { get; set; }
        public AcademicLevel AcademicLevel { get; set; }
        public string PositionID { get; set; }
        public string YearStartWork { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; } = null;
    }
}
