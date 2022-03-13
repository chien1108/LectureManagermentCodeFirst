using LecturerManagement.Core.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// Môn Học
    /// </summary>
    public class Subject : BaseEntity<string>
    {
        //[Key]
        //public string ID { get; set; }

        /// <summary>
        /// Môn Học Thuộc Hệ Đào Tạo
        /// </summary>
        [ForeignKey("TrainingSystem")]
        public string TrainingSystemId { get; set; }

        /// <summary>
        /// Loại Môn
        /// </summary>
        [ForeignKey("SubjectType")]
        public string SubjectTypeId { get; set; }

        /// <summary>
        /// Tên Môn
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Số Tiết
        /// </summary>
        public int QuantityUnit { get; set; }

        /// <summary>
        /// Ghi Chú
        /// </summary>
        public string Description { get; set; }

        public TrainingSystem TrainingSystem { get; set; }
        public SubjectType SubjectType { get; set; }
        public ICollection<Teaching> Teachings { get; set; } = new HashSet<Teaching>();
    }
}