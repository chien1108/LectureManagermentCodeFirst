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
        public byte[] PasswordHash { get; set; }
        public Permission Permission { get; set; }
    }
}
