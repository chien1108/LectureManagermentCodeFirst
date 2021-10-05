using System.Collections.Generic;

namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// lớp
    /// </summary>
    public class Class
    {
        public string ClassID { get; set; }
        public string TrainingSystemID { get; set; }
        public string ClassName { get; set; }
        public int? NumberOfSutdent { get; set; }
        public string FormsOfTraining { get; set; }
        public string? Description { get; set; }

        public TrainingSystem TrainingSystemIDNavigation { get; set; }
        public ICollection<Teaching> Teachings { get; set; }
        public ICollection<GraduationThesis> GraduationTheses { get; set; }

        public Class()
        {
            Teachings = new HashSet<Teaching>();
            GraduationTheses = new HashSet<GraduationThesis>();
        }
    }
}
