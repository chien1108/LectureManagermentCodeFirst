using LecturerManagement.Core.Models.Base;
using System.Collections.Generic;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// Bộ Môn
    /// </summary>
    public class SubjectDepartment : BaseEntity<string>
    {
        //[Key]
        //public string ID { get; set; }
        /// <summary>
        /// Tên Bộ Môn
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ghi Chú
        /// </summary>
        public string Description { get; set; } = null;

        public ICollection<Lecturer> Lecturers { get; set; } = new HashSet<Lecturer>();
    }
}