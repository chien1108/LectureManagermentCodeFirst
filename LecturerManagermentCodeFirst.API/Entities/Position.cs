using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Entities
{
    public class Position
    {
        public string PositionID { get; set; }
        public string PositionName { get; set; }
        public int? DiscountPercent { get; set; }
        public string? Description { get; set; }

        public ICollection<Lecturer> Lecturers { get; set; }
    }
}
