using LecturerManagermentCodeFirst.DTO.Enum;
using System;

namespace LecturerManagermentCodeFirst.API.Entities
{
    public class Account
    {
        public string LecturerID { get; set; }
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public Permission Permission { get; set; }
        public DateTime? DateCreated { get; set; }


        //1-1 nha not 1-n chừng nào n là List<Lecturer> thì mới là 1 - n
        public Lecturer LecturerIDNavigation { get; set; }
    }
}
