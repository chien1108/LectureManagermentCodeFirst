using System.Collections.Generic;

namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// Môn Học
    /// </summary>
    public class Subject
    {
        public string SubjectID { get; set; }
        public string TrainingSystemID { get; set; }
        public string SubjectTypeID { get; set; }
        public string SubjectName { get; set; }
        public int QuantityUnit { get; set; }
        public string Description { get; set; }

        public TrainingSystem TrainingSystemIDNavigation { get; set; }
        public SubjectType SubjectTypeIDNavigation { get; set; }
        public ICollection<Teaching> Teaches { get; set; }

        public Subject()
        {
            Teaches = new HashSet<Teaching>();
        }
    }
}