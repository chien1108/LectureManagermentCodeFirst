using LecturerManagement.Core.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// Lớp
    /// </summary>
    public class Class : BaseEntity<string>
    {
        //[Key]
        //public string ID { get; set; } // VD 69DCHT21

        /// <summary>
        /// Hệ Đào Tạo
        /// </summary>
        [ForeignKey("TrainingSystem")]
        public string TrainingSystemId { get; set; }

        /// <summary>
        /// Tên Lớp
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Sĩ Số
        /// </summary>
        public int? NumberOfStudent { get; set; }

        /// <summary>
        /// Hình Thức Đào Tạo[Tín Chỉ, Niên chế,....]
        /// </summary>
        public string FormsOfTraining { get; set; }

        public string Description { get; set; } = null;

        public TrainingSystem TrainingSystem { get; set; }
        public ICollection<Teaching> Teachings { get; set; } = new HashSet<Teaching>();
        public ICollection<GraduationThesis> GraduationTheses { get; set; } = new HashSet<GraduationThesis>();
    }
}