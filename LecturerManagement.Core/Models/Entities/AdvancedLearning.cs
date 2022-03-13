using LecturerManagement.Core.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// Học BS Nâng Cao
    /// </summary>
    public class AdvancedLearning : BaseEntity<string>
    {
        //[Key]
        //public int ID { get; set; } // auto

        /// <summary>
        /// Ma GV Tham Gia Học Nâng Cao
        /// </summary>
        [ForeignKey("Lecturer")]
        public string LecturerID { get; set; }

        /// <summary>
        /// Năm Học
        /// </summary>
        [Required]
        public string SchoolYear { get; set; }

        /// <summary>
        /// Ghi Chú
        /// </summary>
        public string Description { get; set; } = null;

        public Lecturer Lecturer { get; set; }
    }
}