namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// GV NCKH
    /// </summary>
    public class LecturerScientificResearch
    {
        public string TopicID { get; set; }
        public string LecturerID { get; set; }
        public string TopicName { get; set; }
        public string LevelOfResearch { get; set; }
        public string YearOfResearchParticipation { get; set; }
        public string? Description { get; set; }

        public Lecturer LecturerIDNavigation { get; set; }
    }
}