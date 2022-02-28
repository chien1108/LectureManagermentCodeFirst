using LecturerManagement.DTOS.Models.Base;

namespace LecturerManagement.DTOS.Position
{
    public class GetPositionDto : BaseEntity<string>
    {
        //public string ID { get; set; }

        public string Name { get; set; }
        public int? DiscountPercent { get; set; }
        public string Description { get; set; } = null;

        //public ICollection<Lecturer> Lecturers { get; set; }
    }
}
