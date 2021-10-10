using LecturerManagermentCodeFirst.DTO.DTOS.TrainingSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.DTO.DTOS.Class
{
    public class GetClassDto
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int? NumberOfStudent { get; set; }
        public string FormsOfTraining { get; set; }
        public string Description { get; set; } = null;
        public GetTrainingSystemDto TrainingSystem { get; set; }
    }
}
