using LecturerManagement.DTOS.LecturerDTO;
using System.Collections.Generic;

namespace LecturerManagement.DTOS.StandardTime
{
    public class GetStandardTimeDto
    {
        public string ID { get; set; }

        public string Name { get; set; }
        public int StandardHours { get; set; }
        public string Description { get; set; } = null;
        public ICollection<GetLecturerDto> Lecturers { get; set; }
    }
}
