using LecturerManagement.Core.Modules.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace LecturerManagement.Core.Models.Base
{
    public class BaseEntity<T> : IBaseEntity<T>
    {
        private DateTime? _createdDate;

        [Required]
        public T Id { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate
        {
            get { return _createdDate ?? DateTime.Now; }
            set { _createdDate = value; }
        }

        public DateTime? ModifiedDate { get; set; }
    }
}
