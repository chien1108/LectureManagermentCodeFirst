namespace LecturerManagement.DTOS.SubjectDepartment
{
    public class GetSubjectDepartmentDto
    {
        public string Name { get; set; }
        public string Description { get; set; } = null;

        //public ICollection<Lecturer> Lecturers { get; set; } = new HashSet<Lecturer>();
    }
}
