namespace LecturerManagement.DTOS.LecturerScientificResearch
{
    public class UpdateLecturerScientificResearchDto
    {
        public string LecturerID { get; set; }

        public string Name { get; set; }
        public string LevelOfResearch { get; set; }
        public string YearOfResearchParticipation { get; set; }
        public string Description { get; set; } = null;

        //public Lecturer Lecturer { get; set; }
    }
}
