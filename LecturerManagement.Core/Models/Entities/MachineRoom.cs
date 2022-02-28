using LecturerManagement.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// Phòng máy
    /// </summary>
    public class MachineRoom : BaseEntity<string>
    {
        //[Key]
        //public string ID { get; set; }

        [ForeignKey("Lecturer")]
        public string LecturerId { get; set; }

        public int QantityRoom { get; set; }
        public string SchoolYear { get; set; }
        public string Description { get; set; } = null;

        public Lecturer Lecturer { get; set; }
    }
}