using LecturerManagermentCodeFirst.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.DTO.DTOS.Account
{
    public class UpdateAccountDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Permission Permission { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public Status Status { get; set; }
        public DateTime? BirthDate { get; set; }
        public string IdentityCardNumber { get; set; }
        public string Portrait { get; set; }
        public string AcademicLevel { get; set; }
        public string YearStartWork { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; } = null;
        public DateTime? DateCreated { get; set; }
    }
}
