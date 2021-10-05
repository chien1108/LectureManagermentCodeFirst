namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// Phòng máy
    /// </summary>
    public class MachineRoom
    {
        public string MachineRoomID { get; set; }
        public string LecturerID { get; set; }
        public int QantityRoom { get; set; }
        public string SchoolYear { get; set; }
        public string? Description { get; set; }

        public Lecturer LecturerIDNavigation { get; set; }
    }
}
