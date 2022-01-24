using LecturerManagement.DTOS.Modules.Enums;
using System;

namespace LecturerManagement.DTOS.Models.Base
{
    public interface IBaseEntity<T>
    {
        T Id { get; set; }

        Status Status { get; set; }

        DateTime CreatedDate { get; set; }

        DateTime? ModifiedDate { get; set; }
    }
}