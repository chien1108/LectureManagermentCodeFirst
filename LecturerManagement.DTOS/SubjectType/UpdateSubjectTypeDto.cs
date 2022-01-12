namespace LecturerManagement.DTOS.SubjectType
{
    public class UpdateSubjectTypeDto
    {
        public string Name { get; set; }
        public string Description { get; set; } = null;

        //public ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();
    }
}
