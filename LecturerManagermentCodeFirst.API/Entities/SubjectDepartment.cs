using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// Bộ môn
    /// </summary>
    public class SubjectDepartment
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } = null;

        public ICollection<Lecturer> Lecturers { get; set; } = new HashSet<Lecturer>();
    }
}
