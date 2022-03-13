using LecturerManagement.Core.Models.Base;
using System.Collections.Generic;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// Chức Vụ
    /// </summary>
    public class Position : BaseEntity<string>
    {
        //[Key]
        //public string ID { get; set; }
        /// <summary>
        /// Tên Chức Vụ
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Phần Trăm Số Giờ Được Giảm
        /// </summary>
        public int? DiscountPercent { get; set; }

        /// <summary>
        /// Ghi Chú
        /// </summary>
        public string Description { get; set; } = null;

        public ICollection<Lecturer> Lecturers { get; set; }
    }
}