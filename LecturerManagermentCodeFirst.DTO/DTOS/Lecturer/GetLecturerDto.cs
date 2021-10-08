using LecturerManagermentCodeFirst.DTO.DTOS.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.DTO.DTOS.Lecturer
{
    public class GetLecturerDto
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string IdentityCardNumber { get; set; }
        public string Portrait { get; set; }
        public string AcademicLevel { get; set; }
        public string PositionID { get; set; }
        public string YearStartWork { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; } = null;
        public GetAccountDto Account { get; set; }
    }
}

