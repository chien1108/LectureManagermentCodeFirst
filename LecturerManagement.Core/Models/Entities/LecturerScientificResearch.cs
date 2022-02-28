using LecturerManagement.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// GV NCKH
    /// </summary>
    public class LecturerScientificResearch : BaseEntity<string>
    {
        //[Key]
        //public string ID { get; set; }

        [ForeignKey("Lecturer")]
        public string LecturerId { get; set; }

        public string Name { get; set; }
        public string LevelOfResearch { get; set; }
        public string YearOfResearchParticipation { get; set; }
        public string Description { get; set; } = null;

        public Lecturer Lecturer { get; set; }
    }
}