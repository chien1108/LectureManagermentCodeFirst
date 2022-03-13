using LecturerManagement.Core.Models.Base;

namespace LecturerManagement.Core.Models.Entities
{
    /// <summary>
    /// Hệ Số Lớp Động
    /// </summary>
    public class DynamicClassFactor : BaseEntity<string>
    {
        //[Key]
        //public string ID { get; set; } // HSD

        /// <summary>
        /// Từ
        /// </summary>
        public int? FromDynamic { get; set; }

        /// <summary>
        /// Đến
        /// </summary>
        public int? ToDynamic { get; set; }

        /// <summary>
        /// hệ số
        /// </summary>
        public double Coefficient { get; set; }

        /// <summary>
        /// Hình Thức Dạy[Lý Thuyết, Thực Hành]
        /// </summary>
        public string TeachesForm { get; set; }
    }
}