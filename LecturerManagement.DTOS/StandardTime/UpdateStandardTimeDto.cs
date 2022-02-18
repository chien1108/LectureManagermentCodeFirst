using LecturerManagement.DTOS.Models.Base;

namespace LecturerManagement.DTOS.StandardTime
{
    public class UpdateStandardTimeDto : BaseEntity<string>
    {
        ///public string Id { get; set; }

        public string Name { get; set; }
        public int StandardHours { get; set; }
        public string Description { get; set; } = null;

    }
}
