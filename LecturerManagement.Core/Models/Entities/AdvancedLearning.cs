using LecturerManagement.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// học nâng cao
    /// </summary>
    public class AdvancedLearning : BaseEntity<int>
    {
        //[Key]
        //public int ID { get; set; } // auto

        [ForeignKey("Lecturer")]
        public string LecturerID { get; set; }

        public string SchoolYear { get; set; }
        public string Description { get; set; } = null;

        public Lecturer Lecturer { get; set; }
    }
}