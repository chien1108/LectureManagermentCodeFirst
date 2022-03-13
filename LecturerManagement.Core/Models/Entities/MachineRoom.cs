using LecturerManagement.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// Quản Lý Phòng Máy
    /// </summary>
    public class MachineRoom : BaseEntity<string>
    {
        //[Key]
        //public string ID { get; set; }

        /// <summary>
        /// Mã GV quản lý
        /// </summary>
        [ForeignKey("Lecturer")]
        public string LecturerId { get; set; }

        /// <summary>
        /// Số Lượng PM
        /// </summary>
        public int QantityRoom { get; set; }

        /// <summary>
        /// Năm Học
        /// </summary>
        public string SchoolYear { get; set; }

        /// <summary>
        /// Ghi Chú
        /// </summary>
        public string Description { get; set; } = null;

        public Lecturer Lecturer { get; set; }
    }
}