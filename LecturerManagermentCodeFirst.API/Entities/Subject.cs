using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// Môn Học
    /// </summary>
    public class Subject
    {
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
        public ICollection<Teaching> Teaches { get; set; } = new HashSet<Teaching>();
    }
}
