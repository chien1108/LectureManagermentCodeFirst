using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// Môn Học
    /// </summary>
    public class Subject
    {
        [Key]
        public string ID { get; set; }

        [ForeignKey("TrainingSystem")]
        public string TrainingSystemID { get; set; }

        [ForeignKey("SubjectType")]
        public string SubjectTypeID { get; set; }

        public string Name { get; set; }
        public int QuantityUnit { get; set; }
        public string Description { get; set; }

        public TrainingSystem TrainingSystem { get; set; }
        public SubjectType SubjectType { get; set; }
        public ICollection<Teaching> Teachings { get; set; } = new HashSet<Teaching>();
    }
}