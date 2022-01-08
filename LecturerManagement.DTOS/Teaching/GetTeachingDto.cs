using LecturerManagement.DTOS.Class;
using LecturerManagement.DTOS.LecturerDTO;
using LecturerManagement.DTOS.Subject;

namespace LecturerManagement.DTOS.Teaching
{
    public class GetTeachingDto
    {

        public int NumberOfStudents { get; set; }
        public string SchoolYear { get; set; }
        public string Description { get; set; } = null;

        public GetLecturerScientificResearchDto Lecturer { get; set; }
        public GetClassDto Class { get; set; }
        public GetSubjectDto Subject { get; set; }
    }
}
