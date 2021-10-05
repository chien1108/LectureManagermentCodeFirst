using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// học nâng cao
    /// </summary>
    public class AdvancedLearning
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Lecturer")]
        public string LecturerID { get; set; }
        public string SchoolYear { get; set; }
        public string Description { get; set; } = null;

        public Lecturer Lecturer { get; set; }
    }
}
