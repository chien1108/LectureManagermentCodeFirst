using LecturerManagement.DTOS.Models.Base;
using LecturerManagement.DTOS.TrainingSystem;

namespace LecturerManagement.DTOS.Class
{
    public class GetClassDto : BaseEntity<string>
    {
        ////public string ID { get; set; }
        public string Name { get; set; }
        public int? NumberOfStudent { get; set; }
        public string FormsOfTraining { get; set; }
        public string Description { get; set; } = null;
        public GetTrainingSystemDto TrainingSystem { get; set; }
    }
}
