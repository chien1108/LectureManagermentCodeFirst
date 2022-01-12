namespace LecturerManagement.DTOS.TrainingSystem
{
    public class UpdateTrainingSystemDto
    {
        public string Name { get; set; }
        public int NumberOfLearningUnit { get; set; }
        public string Description { get; set; } = null;

        // [Required]
        //public ICollection<Class> Classes { get; set; } = new HashSet<Class>();
        //public ICollection<Subject> Subjects { get; set; } = new HashSet<Subject>();
    }
}
