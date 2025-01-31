﻿using LecturerManagermentCodeFirst.DTO.DTOS.Subject;
using System.Collections.Generic;

namespace LecturerManagermentCodeFirst.DTO.DTOS.SubjectType
{
    public class GetSubjectTypeDto
    {
        //public string ID { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<GetSubjectDto> Subjects { get; set; } = new HashSet<GetSubjectDto>();
    }
}
