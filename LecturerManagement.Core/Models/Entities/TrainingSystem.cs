using LecturerManagement.Core.Models.Base;
using System.Collections.Generic;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// Hệ Đào Tạo
    /// </summary>
    public class TrainingSystem : BaseEntity<string>
    {
        //[Key]
        //public string ID { get; set; }// DTCD

        /// <summary>
        /// Tên Hệ Đào Tạo
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Số Buổi Trên 1 Đơn Vị Học Trình
        /// </summary>
        public int NumberOfLearningUnit { get; set; }

        /// <summary>
        /// Ghi Chú
        /// </summary>
        public string Description { get; set; } = null;

        // [Required]
        public ICollection<Class> Classes { get; set; } = new HashSet<Class>();

        public ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();
    }
}