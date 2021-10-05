namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// học nâng cao
    /// </summary>
    public class AdvancedLearning
    {
        public int AdvancedLearningID { get; set; }
        public string LecturerID { get; set; }
        public string SchoolYear { get; set; }
        public string? Description { get; set; }

        public Lecturer LecturerIDNavigation { get; set; }
    }
}
