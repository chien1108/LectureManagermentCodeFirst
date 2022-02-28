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

        [ForeignKey("TrainingSystem")]
        public string TrainingSystemId { get; set; }

        [ForeignKey("SubjectType")]
        public string SubjectTypeId { get; set; }

        public string Name { get; set; }
        public int QuantityUnit { get; set; }
        public string Description { get; set; }

        public TrainingSystem TrainingSystem { get; set; }
        public SubjectType SubjectType { get; set; }
        public ICollection<Teaching> Teachings { get; set; } = new HashSet<Teaching>();
    }
}