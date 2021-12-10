using LecturerManagement.Core.Models.Base;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// hệ số lớp động
    /// </summary>
    public class DynamicClassFactor : BaseEntity<string>
    {
        //[Key]
        //public string ID { get; set; } // HSD

        public int? FromDynamic { get; set; }
        public int? ToDynamic { get; set; }

        /// <summary>
        /// hệ số
        /// </summary>
        public double Coefficient { get; set; }

        public string TeachesForm { get; set; }
    }
}