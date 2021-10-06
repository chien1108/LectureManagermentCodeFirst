using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// lớp
    /// </summary>
    public class Class
    {
        [Key]
        public string ID { get; set; }

        [ForeignKey("TrainingSystem")]
        public string TrainingSystemID { get; set; }

        public string Name { get; set; }
        public int? NumberOfStudent { get; set; }
        public string FormsOfTraining { get; set; }
        public string Description { get; set; } = null;

        public TrainingSystem TrainingSystem { get; set; }
        public ICollection<Teaching> Teachings { get; set; } = new HashSet<Teaching>();
        public ICollection<GraduationThesis> GraduationTheses { get; set; } = new HashSet<GraduationThesis>();
    }
}