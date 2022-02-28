using LecturerManagement.DTOS.Models.Base;

namespace LecturerManagement.DTOS.TrainingSystem
{
    public class GetTrainingSystemDto : BaseEntity<string>
    {
        //public string ID { get; set; }
        public string Name { get; set; }
        public int NumberOfLearningUnit { get; set; }
        public string Description { get; set; } = null;

        //public ICollection<GetClassDto> Classes { get; set; }
        //public ICollection<GetSubjectDto> Subjects { get; set; }
    }
}
