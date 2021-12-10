using LecturerManagement.Core.Models.Entities;

namespace LecturerManagement.DTOS.AdvancedLearning
{
    public class GetAdvancedLearningDto
    {
        public int ID { get; set; } // auto

        public string SchoolYear { get; set; }
        public string Description { get; set; } = null;

        public Lecturer Lecturer { get; set; }
    }
}
