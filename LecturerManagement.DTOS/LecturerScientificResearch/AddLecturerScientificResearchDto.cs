using LecturerManagement.DTOS.Modules.Enums;

namespace LecturerManagement.DTOS.LecturerScientificResearch
{
    public class AddLecturerScientificResearchDto
    {
        public string LecturerID { get; set; }

        public string Name { get; set; }
        public ScientificResearchLevel LevelOfResearch { get; set; }
        public string YearOfResearchParticipation { get; set; }
        public string Description { get; set; } = null;

        // public Lecturer Lecturer { get; set; }
    }
}
