using System.Collections.Generic;

namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// hệ đào tạo
    /// </summary>
    public class TrainingSystem
    {
        public string TrainingSystemID { get; set; }
        public string TrainingSystemName { get; set; }
        public int NumberOfLearningUnit { get; set; }
        public string? Description { get; set; }

        public ICollection<Class> Classes { get; set; }
        public ICollection<Subject> Subjects { get; set; }

        public TrainingSystem()
        {
            Classes = new HashSet<Class>();
            Subjects = new HashSet<Subject>();
        }
    }
}
