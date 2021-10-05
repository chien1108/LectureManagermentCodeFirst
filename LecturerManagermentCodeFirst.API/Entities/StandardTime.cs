using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Entities
{
    public class StandardTime
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int StandardHours { get; set; }
        public string? Description { get; set; }

        public ICollection<Lecturer> Lecturers { get; set; }
    }
}
