﻿using LecturerManagement.Core.Models.Base;
using System.Collections.Generic;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// Bộ môn
    /// </summary>
    public class SubjectDepartment : BaseEntity<string>
    {
        //[Key]
        //public string ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; } = null;

        public ICollection<Lecturer> Lecturers { get; set; } = new HashSet<Lecturer>();
    }
}