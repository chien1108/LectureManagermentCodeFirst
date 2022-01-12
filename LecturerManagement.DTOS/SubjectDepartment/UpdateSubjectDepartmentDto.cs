namespace LecturerManagement.DTOS.SubjectDepartment
{
    public class UpdateSubjectDepartmentDto
    {
        public string Name { get; set; }
        public string Description { get; set; } = null;

        //public ICollection<Lecturer> Lecturers { get; set; } = new HashSet<Lecturer>();
    }
}
