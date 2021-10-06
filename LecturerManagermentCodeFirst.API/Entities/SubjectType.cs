using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// loại môn
    /// </summary>
    public class SubjectType
    {
        [Key]
        public string ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; } = null;

        public ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();
    }
}