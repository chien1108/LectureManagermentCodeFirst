using LecturerManagement.Core.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// Giảng Dạy
    /// </summary>
    public class Teaching : BaseEntity<string>
    {
        /// <summary>
        /// Mã GV Tham Gia Giảng Dạy
        /// </summary>
        [ForeignKey("Lecturer")]
        public string LectureId { get; set; }

        /// <summary>
        /// Mã Lớp
        /// </summary>
        [ForeignKey("Class")]
        public string ClassId { get; set; }

        /// <summary>
        /// Môn Học
        /// </summary>
        [ForeignKey("Subject")]
        public string SubjectId { get; set; }

        /// <summary>
        /// Số Sinh Viên
        /// </summary>
        public int NumberOfStudents { get; set; }

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
        public Subject Subject { get; set; }
    }
}