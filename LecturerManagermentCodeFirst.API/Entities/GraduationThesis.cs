using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagermentCodeFirst.API.Entities
{
    // đồ án tốt nghiệp
    public class GraduationThesis
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Lecturer")]
        public string LecturerID { get; set; }
        [ForeignKey("Class")]
        public string ClassID { get; set; }
        public int? TopicNumbers { get; set; }
        public int? RebuttalProjectNumbers { get; set; }
        public int? MarkSessionNumbers { get; set; }
        public string SchoolYear { get; set; }
        public string Description { get; set; } = null;

        public Lecturer Lecturer { get; set; }
        public Class Class { get; set; }
    }
}
