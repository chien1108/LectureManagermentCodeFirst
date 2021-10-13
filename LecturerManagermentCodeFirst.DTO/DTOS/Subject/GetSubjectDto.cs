using LecturerManagermentCodeFirst.DTO.DTOS.SubjectType;
using LecturerManagermentCodeFirst.DTO.DTOS.Teaching;
using LecturerManagermentCodeFirst.DTO.DTOS.TrainingSystem;
using System.Collections.Generic;

namespace LecturerManagermentCodeFirst.DTO.DTOS.Subject
{
    public class GetSubjectDto
    {
        //public string ID { get; set; }
        public string Name { get; set; }
        public int QuantityUnit { get; set; }
        public string Description { get; set; }

        public GetTrainingSystemDto TrainingSystem { get; set; }
        public GetSubjectTypeDto SubjectType { get; set; }
        public ICollection<GetTeachingDto> Teachings { get; set; } = new HashSet<GetTeachingDto>();
    }
}
