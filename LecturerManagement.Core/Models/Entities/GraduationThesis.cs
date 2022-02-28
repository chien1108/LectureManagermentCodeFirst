using LecturerManagement.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagement.Core.Models.Entities
{
    // đồ án tốt nghiệp
    public class GraduationThesis : BaseEntity<string>
    {
        //[Key]
        //public int ID { get; set; } //auto

        [ForeignKey("Lecturer")]
        public string LecturerId { get; set; }

        [ForeignKey("Class")]
        public string ClassId { get; set; }

        public int? TopicNumbers { get; set; }
        public int? RebuttalProjectNumbers { get; set; }
        public int? MarkSessionNumbers { get; set; }
        public string SchoolYear { get; set; }
        public string Description { get; set; } = null;

        public Lecturer Lecturer { get; set; }
        public Class Class { get; set; }
    }
}