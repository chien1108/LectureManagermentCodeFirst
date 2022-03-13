using LecturerManagement.Core.Models.Base;
using LecturerManagement.DTOS.Modules.Enums;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagement.Core.Models.Entities
{
    public class Account : BaseEntity<string>
    {
        //[Key]
        //public int ID { get; set; } // auto increa

        [ForeignKey("Lecturer")]
        public string LecturerId { get; set; }

        [Required]
        public string UserName { get; set; }

        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        [Required]
        public Permission Permission { get; set; }

        public DateTime? DateCreated { get; set; }

        //1-1 nha not 1-n chừng nào n là List<Lecturer> thì mới là 1 - n
        public Lecturer Lecturer { get; set; }
    }
}