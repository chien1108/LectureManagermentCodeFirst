using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Entities
{
    // đồ án tốt nghiệp
    public class GraduationThesis
    {
        public int GraduationThesisID { get; set; }
        public string LecturerID { get; set; }
        public string ClassID { get; set; }
        public int? TopicNumbers { get; set; }
        public int? RebuttalProjectNumbers { get; set; }
        public int? MarkSessionNumbers { get; set; }
        public string SchoolYear { get; set; }
        public string? Description { get; set; }

        public Lecturer LecturerIDNavigation { get; set; }
        public Class ClassIDNavigation { get; set; }
    }
}
