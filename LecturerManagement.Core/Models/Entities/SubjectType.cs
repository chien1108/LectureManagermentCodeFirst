using LecturerManagement.Core.Models.Base;
using System.Collections.Generic;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// loại môn
    /// </summary>
    public class SubjectType : BaseEntity<string>
    {
        //[Key]
        ///public string ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; } = null;

        public ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();
    }
}