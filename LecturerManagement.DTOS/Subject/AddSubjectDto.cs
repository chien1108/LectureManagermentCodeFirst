namespace LecturerManagement.DTOS.Subject
{
    public class AddSubjectDto
    {
        //[ForeignKey("TrainingSystem")]
        public string TrainingSystemID { get; set; }

        //[ForeignKey("SubjectType")]
        public string SubjectTypeID { get; set; }

        public string Name { get; set; }
        public int QuantityUnit { get; set; }
        public string Description { get; set; }

        //public TrainingSystem TrainingSystem { get; set; }
        //public SubjectType SubjectType { get; set; }
        //public ICollection<Teaching> Teachings { get; set; } = new HashSet<Teaching>();
    }
}
