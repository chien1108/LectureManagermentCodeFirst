using LecturerManagermentCodeFirst.DTO.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagermentCodeFirst.API.Entities
{
    public class Lecturer
    {
        [Key]
        public string ID { get; set; }

        [ForeignKey("StandardTime")]
        public string StandardTimeID { get; set; }

        [ForeignKey("SubjectDepartment")]
        public string SubjectDepartmentID { get; set; }
        public Status Status { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public DateTime? BirthDate { get; set; }
        public string IdentityCardNumber { get; set; }
        public string Portrait { get; set; }
        public string AcademicLevel { get; set; }
        public string PositionID { get; set; }
        public string YearStartWork { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; } = null;

        public SubjectDepartment SubjectDepartment { get; set; }
        public StandardTime StandardTime { get; set; }
        public Position Position { get; set; }
        public ICollection<GraduationThesis> GraduationTheses { get; set; } = new HashSet<GraduationThesis>();
        public ICollection<Teaching> Teaches { get; set; } = new HashSet<Teaching>();
        public ICollection<LecturerScientificResearch> LecturerScientificResearches { get; set; } = new HashSet<LecturerScientificResearch>();
        public ICollection<AdvancedLearning> AdvancedLearnings { get; set; } = new HashSet<AdvancedLearning>();
        public ICollection<ScientificResearchGuide> ScientificResearchGuides { get; set; } = new HashSet<ScientificResearchGuide>();
        public ICollection<MachineRoom> MachineRooms { get; set; } = new HashSet<MachineRoom>();
        public Account Account { get; set; }
    }
}