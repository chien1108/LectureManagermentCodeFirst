using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Entities
{
    public class StandardTime
    {
        public string StandardTimeID { get; set; }
        public string StandardTimeName { get; set; }
        public int StandardHours { get; set; }
        public string? Description { get; set; }

        public ICollection<Lecturer> Lecturers { get; set; }

        public StandardTime()
        {
            Lecturers = new HashSet<Lecturer>();
        }
    }
}
