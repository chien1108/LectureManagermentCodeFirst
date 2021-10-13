using LecturerManagermentCodeFirst.DTO.DTOS.Class;
using LecturerManagermentCodeFirst.DTO.DTOS.Lecturer;
using LecturerManagermentCodeFirst.DTO.DTOS.Subject;

namespace LecturerManagermentCodeFirst.DTO.DTOS.Teaching
{
    public class GetTeachingDto
    {

        public int NumberOfStudents { get; set; }
        public string SchoolYear { get; set; }
        public string Description { get; set; } = null;

        public GetLecturerDto Lecturer { get; set; }
        public GetClassDto Class { get; set; }
        public GetSubjectDto Subject { get; set; }
    }
}
