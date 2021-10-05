using System.Collections.Generic;

namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// hệ đào tạo
    /// </summary>
    public class TrainingSystem
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int NumberOfLearningUnit { get; set; }
        public string? Description { get; set; }

        public ICollection<Class> Classes { get; set; } = new HashSet<Class>();
        public ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();
    }
}
