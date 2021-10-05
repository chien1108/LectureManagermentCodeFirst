using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LecturerManagermentCodeFirst.API.Entities
{
    public class Position
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public int? DiscountPercent { get; set; }
        public string Description { get; set; } = null;

        public ICollection<Lecturer> Lecturers { get; set; }
    }
}
