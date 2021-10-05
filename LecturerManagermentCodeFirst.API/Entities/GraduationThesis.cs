using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Entities
{
    // đồ án tốt nghiệp
    public class GraduationThesis
    {
        public int ID { get; set; }
        [ForeignKey("Lecturer")]
        public string LecturerID { get; set; }
        [ForeignKey("Class")]
        public string ClassID { get; set; }
        public int? TopicNumbers { get; set; }
        public int? RebuttalProjectNumbers { get; set; }
        public int? MarkSessionNumbers { get; set; }
        public string SchoolYear { get; set; }
        public string? Description { get; set; }

        public Lecturer Lecturer { get; set; }
        public Class Class { get; set; }
    }
}
