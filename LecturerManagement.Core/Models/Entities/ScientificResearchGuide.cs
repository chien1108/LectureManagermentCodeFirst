using LecturerManagement.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// hướng dẫn NCKH
    /// </summary>
    public class ScientificResearchGuide : BaseEntity<string>
    {
        //[Key]
        //public string ID { get; set; }

        [ForeignKey("Lecturer")]
        public string LecturerID { get; set; }

        public int Quantity { get; set; }
        public string StudentYear { get; set; }
        public string SchoolYear { get; set; }
        public string Description { get; set; } = null;

        public Lecturer Lecturer { get; set; }
    }
}