using LecturerManagement.Core.Models.Base;
using System.Collections.Generic;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// Loại Môn
    /// </summary>
    public class SubjectType : BaseEntity<string>
    {
        //[Key]
        //public string ID { get; set; }
        /// <summary>
        /// Tên Loại Môn
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Ghi Chú
        /// </summary>
        public string Description { get; set; } = null;

        public ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();
    }
}