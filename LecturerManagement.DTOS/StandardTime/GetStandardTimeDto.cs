using LecturerManagement.DTOS.Models.Base;

namespace LecturerManagement.DTOS.StandardTime
{
    public class GetStandardTimeDto : BaseEntity<string>
    {
        ////public string ID { get; set; }

        public string Name { get; set; }
        public int StandardHours { get; set; }
        public string Description { get; set; } = null;
        ////public ICollection<GetLecturerDto> Lecturers { get; set; }
    }
}
