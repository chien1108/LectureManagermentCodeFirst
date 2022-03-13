using LecturerManagement.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// Hướng Dẫn NCKH
    /// </summary>
    public class ScientificResearchGuide : BaseEntity<string>
    {
        //[Key]
        //public string ID { get; set; }

        /// <summary>
        /// Mã GV tham gia HD NCKH
        /// </summary>
        [ForeignKey("Lecturer")]
        public string LecturerId { get; set; }

        /// <summary>
        /// Số Lượng
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Sinh Viên Năm
        /// </summary>
        public string StudentYear { get; set; }

        /// <summary>
        /// Năm học
        /// </summary>
        public string SchoolYear { get; set; }

        /// <summary>
        /// Ghi Chú
        /// </summary>
        public string Description { get; set; } = null;

        public Lecturer Lecturer { get; set; }
    }
}