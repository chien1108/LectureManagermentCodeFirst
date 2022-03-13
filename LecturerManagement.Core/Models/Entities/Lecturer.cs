using LecturerManagement.Core.Models.Base;
using LecturerManagement.DTOS.Modules.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// Giảng Viên
    /// </summary>
    public class Lecturer : BaseEntity<string>
    {
        //[Key]
        //public string ID { get; set; }

        /// <summary>
        /// Giảng Viên Thuộc Giờ Chuẩn
        /// </summary>
        [ForeignKey("StandardTime")]
        public string StandardTimeId { get; set; }

        /// <summary>
        /// Giảng Viên Thuộc Bộ Môn
        /// </summary>
        [ForeignKey("SubjectDepartment")]
        public string SubjectDepartmentId { get; set; }

        /// <summary>
        /// Chức Vụ GV Nắm Giữ
        /// </summary>
        [ForeignKey("Position")]
        public string PositionID { get; set; }

        //public Status Status { get; set; }
        /// <summary>
        /// Họ Và Tên
        /// </summary>
        public string FullName { get; set; }

        /// <summary>
        /// Giới Tính
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Ngày Sinh
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Sô CMT/CCCD
        /// </summary>
        public string IdentityCardNumber { get; set; }

        /// <summary>
        /// Ảnh
        /// </summary>
        public byte[] Portrait { get; set; }

        /// <summary>
        /// Trình Độ Học Vấn
        /// </summary>
        public AcademicLevel AcademicLevel { get; set; }

        /// <summary>
        /// Năm Vào Làm
        /// </summary>
        public string YearStartWork { get; set; }

        /// <summary>
        /// Địa Chỉ Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Địa Chỉ
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Số Điện Thoại
        /// </summary>
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Ghi Chú
        /// </summary>
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