using LecturerManagement.DTOS.Models.Base;

namespace LecturerManagement.DTOS.GraduationThesis
{
    public class GetGraduationThesisDto : BaseEntity<string>
    {
        public int? TopicNumbers { get; set; }
        public int? RebuttalProjectNumbers { get; set; }
        public int? MarkSessionNumbers { get; set; }
        public string SchoolYear { get; set; }
        public string Description { get; set; } = null;
    }
}
