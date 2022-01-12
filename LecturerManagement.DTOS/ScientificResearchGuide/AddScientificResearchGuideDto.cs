namespace LecturerManagement.DTOS.ScientificResearchGuide
{
    public class AddScientificResearchGuideDto
    {
        public string LecturerID { get; set; }

        public int Quantity { get; set; }
        public string StudentYear { get; set; }
        public string SchoolYear { get; set; }
        public string Description { get; set; } = null;

        // public Lecturer Lecturer { get; set; }
    }
}
