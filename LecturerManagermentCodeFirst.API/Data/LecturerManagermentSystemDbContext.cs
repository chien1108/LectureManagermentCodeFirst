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
            modelBuilder.Entity<Teaching>(entity => 
            { 
                entity.HasKey(e => new { e.SubjectID, e.LectureID, e.ClassID }); 
            });
        }
    }
}
