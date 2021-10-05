namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// hướng dẫn NCKH
    /// </summary>
    public class ScientificResearchGuide
    {
        public string ScientificResearchGuideID { get; set; }
        public string LecturerID { get; set; }
        public int Quantity { get; set; }
        public string StudentYear { get; set; }
        public string SchoolYear { get; set; }
        public string? Description { get; set; }

        public Lecturer LecturerIDNavigation { get; set; }
    }
}