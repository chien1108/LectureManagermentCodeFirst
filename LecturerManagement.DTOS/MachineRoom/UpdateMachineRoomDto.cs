namespace LecturerManagement.DTOS.MachineRoom
{
    public class UpdateMachineRoomDto
    {
        public string LecturerID { get; set; }

        public int QantityRoom { get; set; }
        public string SchoolYear { get; set; }
        public string Description { get; set; } = null;

        //public Lecturer Lecturer { get; set; }
    }
}
