using LecturerManagement.DTOS.Class;
using LecturerManagement.DTOS.LecturerDTO;
using LecturerManagement.DTOS.Models.Base;
using LecturerManagement.DTOS.Subject;

namespace LecturerManagement.DTOS.Teaching
{
    public class GetTeachingDto : BaseEntity<string>
    {
        ////public int Id { get; set; }
        public int NumberOfStudents { get; set; }
        public string SchoolYear { get; set; }
        public string Description { get; set; } = null;

        public GetLecturerDto Lecturer { get; set; }
        public GetClassDto Class { get; set; }
        public GetSubjectDto Subject { get; set; }
    }
}
