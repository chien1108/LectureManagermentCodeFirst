using LecturerManagermentCodeFirst.DTO.Enum;
using System;
using System.ComponentModel.DataAnnotations;

namespace LecturerManagermentCodeFirst.API.Entities
{
    public class Account
    {
        [Required]
        public string LecturerID { get; set; }

        [Required]
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [Required]
        public Permission Permission { get; set; }
        public DateTime? DateCreated { get; set; }


        //1-1 nha not 1-n chừng nào n là List<Lecturer> thì mới là 1 - n
        public Lecturer LecturerIDNavigation { get; set; }
    }
}
