using LecturerManagement.DTOS.Models.Base;

namespace LecturerManagement.DTOS.AdvancedLearning
{
    public class UpdateAdvancedLearningDto : BaseEntity<int>
    {

        public string LecturerID { get; set; }

        public string SchoolYear { get; set; }
        public string Description { get; set; } = null;

        ///  public Lecturer Lecturer { get; set; }
    }
}
