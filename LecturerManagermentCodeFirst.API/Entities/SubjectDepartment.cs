using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// Bộ môn
    /// </summary>
    public class SubjectDepartment
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public ICollection<Lecturer> Lecturers { get; set; } = new HashSet<Lecturer>();
    }
}
