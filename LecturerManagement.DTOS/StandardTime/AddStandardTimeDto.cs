namespace LecturerManagement.DTOS.StandardTime
{
    public class AddStandardTimeDto
    {
        public string ID { get; set; }

        public string Name { get; set; }
        public int StandardHours { get; set; }
        public string Description { get; set; } = null;

    }
}
