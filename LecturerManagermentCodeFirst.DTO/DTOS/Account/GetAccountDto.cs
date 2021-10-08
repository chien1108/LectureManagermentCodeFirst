using LecturerManagermentCodeFirst.DTO.DTOS.Lecturer;
using LecturerManagermentCodeFirst.DTO.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.DTO.DTOS.Account
{
    public class GetAccountDto
    {
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public Permission Permission { get; set; }
        public DateTime? DateCreated { get; set; }
        public GetLecturerDto Lecturer { get; set; }

    }
}
