using LecturerManagement.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// Đồ Án Tốt Nghiệp
    /// </summary>
    public class GraduationThesis : BaseEntity<string>
    {
        //[Key]
        //public int ID { get; set; } //auto

        /// <summary>
        /// Ma GV Hướng Dẫn
        /// </summary>
        [ForeignKey("Lecturer")]
        public string LecturerId { get; set; }

        /// <summary>
        /// Sinh Viên Thuộc Lớp
        /// </summary>
        [ForeignKey("Class")]
        public string ClassId { get; set; }

        /// <summary>
        /// Số Đề Tài
        /// </summary>
        public int? TopicNumbers { get; set; }

        /// <summary>
        /// Số Đồ Án Phản Biện
        /// </summary>
        public int? RebuttalProjectNumbers { get; set; }

        /// <summary>
        /// Số Buổi Chấm Bài
        /// </summary>
        public int? MarkSessionNumbers { get; set; }

        /// <summary>
        /// Năm Học
        /// </summary>
        public string SchoolYear { get; set; }

        /// <summary>
        /// Ghi Chú
        /// </summary>
        public string Description { get; set; } = null;

        public Lecturer Lecturer { get; set; }
        public Class Class { get; set; }
    }
}