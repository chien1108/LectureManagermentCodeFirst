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
        public string SubjectDepartmentID { get; set; }
        public string SubjectDepartmentName { get; set; }
        public string? Description { get; set; }

        public ICollection<Lecturer> Lecturers { get; set; }

        public SubjectDepartment()
        {
            Lecturers = new HashSet<Lecturer>();
        }
    }
}
