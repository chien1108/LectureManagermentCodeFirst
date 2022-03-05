using LecturerManagement.Core.Models.Entities;
using LecturerManagement.DTOS.Modules.Enums;
using Microsoft.EntityFrameworkCore;
using System;

namespace LecturerManagement.Core.Data
{
    public class LecturerManagementSystemDbContext : DbContext
    {
        public LecturerManagementSystemDbContext()
        {
        }

        public LecturerManagementSystemDbContext(DbContextOptions<LecturerManagementSystemDbContext> options)
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
                entity.HasKey(e => new { e.SubjectId, e.LectureId, e.ClassId });
            });

            modelBuilder.Entity<Account>().Property(x => x.Permission).HasDefaultValue(Permission.Lecturer);

            modelBuilder.Entity<Position>().HasData(
                new Position() { Id = "CV01", Name = "Trưởng Khoa", DiscountPercent = 25, Description = "Giảm 25 phần trăm số giờ chuẩn.", CreatedDate = DateTime.Now, Status = Status.IsActive },
                new Position() { Id = "CV02", Name = "Phó Khoa", DiscountPercent = 20, Description = "Giảm 20 phần trăm số giờ chuẩn.", CreatedDate = DateTime.Now, Status = Status.IsActive },
                new Position() { Id = "CV03", Name = "Trưởng Bộ Môn", DiscountPercent = 20, Description = "Giảm 20 phần trăm số giờ chuẩn.", CreatedDate = DateTime.Now, Status = Status.IsActive },
                new Position() { Id = "CV04", Name = "Không Có Chức Vụ", DiscountPercent = 0, Description = "Dành cho những giảng viên chỉ phụ trách công việc giảng dạy...", CreatedDate = DateTime.Now, Status = Status.IsActive }
                );

            modelBuilder.Entity<SubjectDepartment>().HasData(
                new SubjectDepartment() { Id = "BM01", Name = "Hệ Thống Thông Tin", Description = "Bộ Môn Hệ Thống Thông Tin", Status = Status.IsActive, CreatedDate = DateTime.Now },
                new SubjectDepartment() { Id = "BM02", Name = "Công Nghệ Thông Tin", Description = "Bộ Môn Công Nghệ Thông Tin", Status = Status.IsActive, CreatedDate = DateTime.Now },
                new SubjectDepartment() { Id = "BM03", Name = "Truyền Thông Mạng Máy Tính", Description = "Truyền Thông Mạng Máy Tính", Status = Status.IsActive, CreatedDate = DateTime.Now }
                );
            modelBuilder.Entity<StandardTime>().HasData(
                new StandardTime() { Id = "CD01", Name = "Giáo sư và giảng viên cao cấp", StandardHours = 360, Description = "Số giờ chuẩn cho 1 kỳ học", CreatedDate = DateTime.Now, Status = Status.IsActive },
                new StandardTime() { Id = "CD02", Name = "Phó giáo sư và giảng viên chính", StandardHours = 320, Description = "Số giờ chuẩn cho 1 kỳ học", CreatedDate = DateTime.Now, Status = Status.IsActive },
                new StandardTime() { Id = "CD03", Name = "Giảng viên", StandardHours = 280, Description = "Số giờ chuẩn cho 1 kỳ học", CreatedDate = DateTime.Now, Status = Status.IsActive },
                new StandardTime() { Id = "CD04", Name = "Giảng viên tập sự", StandardHours = 140, Description = "Số giờ chuẩn cho 1 kỳ học", CreatedDate = DateTime.Now, Status = Status.IsActive }
                );
            modelBuilder.Entity<SubjectType>().HasData(
                new SubjectType() { Id = "LM01", Name = "Lý Thuyết", Description = "Môn học lý thuyết", Status = Status.IsActive, CreatedDate = DateTime.Now },
                new SubjectType() { Id = "LM02", Name = "Thực Hành", Description = "Môn học thực hành", Status = Status.IsActive, CreatedDate = DateTime.Now },
                new SubjectType() { Id = "LM03", Name = "Các Đồ án, TTCS,TTCN, TTTN, Project", Description = "Thực tập cơ sở và thực tập tốt nghiệp", Status = Status.IsActive, CreatedDate = DateTime.Now },
                new SubjectType() { Id = "LM04", Name = "Thực tập doanh nghiệp", Description = "Thực tập doanh nghiệp", Status = Status.IsActive, CreatedDate = DateTime.Now },
                new SubjectType() { Id = "LM05", Name = "Thực tập sư phạm", Description = "Thực tập sư phạm", Status = Status.IsActive, CreatedDate = DateTime.Now }
                );
        }
    }
}