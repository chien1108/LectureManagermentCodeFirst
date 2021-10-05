using LecturerManagermentCodeFirst.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LecturerManagermentCodeFirst.API.Data
{
    public class LecturerManagermentSystemDbContext : DbContext
    {
        public LecturerManagermentSystemDbContext()
        {

        }

        public LecturerManagermentSystemDbContext(DbContextOptions<LecturerManagermentSystemDbContext> options) 
            : base(options)
        {

        }
       

        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AdvancedLearning> AdvancedLearnings { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<DynamicClassFactor> DynamicClassFactors { get; set; }
        public DbSet<GraduationThesis> GraduationTheses { get; set; }
        public DbSet<LecturerScientificResearch> LecturerScientificResearches { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<ScientificResearchGuide> ScientificResearchGuides { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubjectType> SubjectTypes { get; set; }
        public DbSet<Teaching> Teachings { get; set; }
        public DbSet<TrainingSystem> TrainingSystems { get; set; }
        public DbSet<SubjectDepartment> SubjectDepartments { get; set; }
        public DbSet<StandardTime> StandardTimes { get; set; }
        public DbSet<MachineRoom> MachineRooms { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>( entity => { entity.HasKey(e => e.UserName); });
            modelBuilder.Entity<AdvancedLearning>(entity => { entity.HasKey(e => e.AdvancedLearningID); });
            modelBuilder.Entity<Class>(entity => { entity.HasKey(e => e.ClassID); });
            modelBuilder.Entity<DynamicClassFactor>(entity => { entity.HasKey(e => e.DynamicClassID); });
            modelBuilder.Entity<GraduationThesis>(entity => { entity.HasKey(e => e.GraduationThesisID); });
            modelBuilder.Entity<Lecturer>(entity => { entity.HasKey(e => e.LecturerID); });
            modelBuilder.Entity<LecturerScientificResearch>(entity => { entity.HasKey(e => e.TopicID); });
            modelBuilder.Entity<MachineRoom>(entity => { entity.HasKey(e => e.MachineRoomID); });
            modelBuilder.Entity<Position>(entity => { entity.HasKey(e => e.PositionID); });
            modelBuilder.Entity<ScientificResearchGuide>(entity => { entity.HasKey(e => e.ScientificResearchGuideID); });
            modelBuilder.Entity<StandardTime>(entity => { entity.HasKey(e => e.StandardTimeID); });
            modelBuilder.Entity<Subject>(entity => { entity.HasKey(e => e.SubjectID); });
            modelBuilder.Entity<SubjectDepartment>(entity => { entity.HasKey(e => e.SubjectDepartmentID); });
            modelBuilder.Entity<SubjectType>(entity => { entity.HasKey(e => e.SubjectTypeID); });
            modelBuilder.Entity<Teaching>(entity => { entity.HasKey(e => new { e.SubjectID, e.LectureID, e.ClassID }); });
            modelBuilder.Entity<TrainingSystem>(entity => { entity.HasKey(e => e.TrainingSystemID); });

        }
    }
}
