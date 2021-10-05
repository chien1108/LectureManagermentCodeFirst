namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// giảng dạy
    /// </summary>
    public class Teaching
    {
        public string LectureID { get; set; }
        public string ClassID { get; set; }
        public string SubjectID { get; set; }
        public int NumberOfStudents { get; set; }
        public string SchoolYear { get; set; }
        public string? Description { get; set; }

        public Lecturer LectureIDNavigation { get; set; }
        public Class ClassIDNavigation { get; set; }
        public Subject SubjectIDNavigation { get; set; }
    }
}