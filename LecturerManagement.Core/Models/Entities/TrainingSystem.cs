using LecturerManagement.Core.Models.Base;
using System.Collections.Generic;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// hệ đào tạo
    /// </summary>
    public class TrainingSystem : BaseEntity<string>
    {
        //[Key]
        //public string ID { get; set; }// DTCD

        public string Name { get; set; }
        public int NumberOfLearningUnit { get; set; }
        public string Description { get; set; } = null;

        // [Required]
        public ICollection<Class> Classes { get; set; } = new HashSet<Class>();
        public ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();
    }
}