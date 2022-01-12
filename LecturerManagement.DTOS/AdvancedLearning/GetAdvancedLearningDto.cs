namespace LecturerManagement.DTOS.AdvancedLearning
{
    public class GetAdvancedLearningDto
    {
        public string LecturerID { get; set; }

        public string SchoolYear { get; set; }
        public string Description { get; set; } = null;

        // public Lecturer Lecturer { get; set; }
    }
}
