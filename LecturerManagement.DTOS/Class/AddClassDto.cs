using LecturerManagement.DTOS.TrainingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturerManagement.DTOS.Class
{
    public class AddClassDto
    {
        public string TrainingSystemID { get; set; }

        public string Name { get; set; }
        public int? NumberOfStudent { get; set; }
        public string FormsOfTraining { get; set; }
        public string Description { get; set; } = null;
        public string TrainingSystemId { get; set; }
        public GetTrainingSystemDto TrainingSystem { get; set; }
    }
}
