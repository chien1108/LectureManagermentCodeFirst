using LecturerManagermentCodeFirst.DTO.DTOS.Lecturer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.DTO.DTOS.StandardTime
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
