using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// GV NCKH
    /// </summary>
    public class LecturerScientificResearch
    {
        public string ID { get; set; }
        [ForeignKey("Lecturer")]
        public string LecturerID { get; set; }
        public string Name { get; set; }
        public string LevelOfResearch { get; set; }
        public string YearOfResearchParticipation { get; set; }
        public string? Description { get; set; }

        public Lecturer Lecturer { get; set; }
    }
}
