using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturerManagement.DTOS.StandardTime
{
    public class UpdateStandardTimeDto
    {
        public string ID { get; set; }

        public string Name { get; set; }
        public int StandardHours { get; set; }
        public string Description { get; set; } = null;

    }
}
