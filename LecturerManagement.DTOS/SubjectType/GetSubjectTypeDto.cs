using LecturerManagement.DTOS.Models.Base;
using LecturerManagement.DTOS.Subject;
using System.Collections.Generic;

namespace LecturerManagement.DTOS.SubjectType
{
    public class GetSubjectTypeDto : BaseEntity<string>
    {
        ////public string Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<GetSubjectDto> Subjects { get; set; } = new HashSet<GetSubjectDto>();
    }
}
