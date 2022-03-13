using LecturerManagement.Core.Models.Base;
using System.Collections.Generic;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// Giờ Chuẩn
    /// </summary>
    public class StandardTime : BaseEntity<string>
    {
        //[Key]
        //public string ID { get; set; }
        /// <summary>
        /// Tên Chức Danh
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Số Giờ Phải Giảng Dạy
        /// </summary>
        public int StandardHours { get; set; }

        /// <summary>
        /// Ghi Chú
        /// </summary>
        public string Description { get; set; } = null;

        public ICollection<Lecturer> Lecturers { get; set; }
    }
}