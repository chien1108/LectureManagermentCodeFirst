using System;
using System.Collections.Generic;

namespace LecturerManagermentCodeFirst.API.Entities
{
    public class Lecturer
    {
        public string LecturerID { get; set; }
        public string LecturerFullName { get; set; }
        public string Sex { get; set; }
        public DateTime? BirthDate { get; set; }
        public string IdentityCardNumber { get; set; }
        public string ImagePath { get; set; }
        public string AcademicLevel { get; set; }
        public string StandardTimeID { get; set; }
        public string PositionID { get; set; }
        public string YearStartWork { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string SubjectDepartmentID { get; set; }
        public string? Description { get; set; }

        public SubjectDepartment SubjectDepartmentIDNavigations { get; set; }
        public StandardTime StandardTimeIDNavigation { get; set; }
        public Position PositionIDNavigation { get; set; }
        public ICollection<GraduationThesis> GraduationTheses { get; set; }
        public ICollection<Teaching> Teaches { get; set; }
        public ICollection<LecturerScientificResearch> LecturerScientificResearches { get; set; }
        public ICollection<AdvancedLearning> AdvancedLearnings { get; set; }
        public ICollection<ScientificResearchGuide> ScientificResearchGuides { get; set; }
        public ICollection<MachineRoom> MachineRooms { get; set; }
        public ICollection<Account> Accounts { get; set; }

        public Lecturer()
        {
            GraduationTheses = new HashSet<GraduationThesis>();
            Teaches = new HashSet<Teaching>();
            LecturerScientificResearches = new HashSet<LecturerScientificResearch>();
            AdvancedLearnings = new HashSet<AdvancedLearning>();
            ScientificResearchGuides = new HashSet<ScientificResearchGuide>();
            MachineRooms = new HashSet<MachineRoom>();
            Accounts = new HashSet<Account>();
        }
    }
}