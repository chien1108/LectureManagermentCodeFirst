using LecturerManagement.Core.Models.Base;
using LecturerManagement.DTOS.Modules.Enums;
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

        /// <summary>
        ///Mã GV tham gia NCKH
        /// </summary>
        [ForeignKey("Lecturer")]
        public string LecturerId { get; set; }

        /// <summary>
        /// Tên Đề Tài
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cấp
        /// </summary>
        public ScientificResearchLevel LevelOfResearch { get; set; }

        /// <summary>
        /// Năm Tham Gia NC
        /// </summary>
        public string YearOfResearchParticipation { get; set; }

        /// <summary>
        /// Ghi Chú
        /// </summary>
        public string Description { get; set; } = null;

        public Lecturer Lecturer { get; set; }
    }
}