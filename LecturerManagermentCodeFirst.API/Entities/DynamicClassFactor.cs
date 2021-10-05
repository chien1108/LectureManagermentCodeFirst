namespace LecturerManagermentCodeFirst.API.Entities
{
    /// <summary>
    /// hệ số lớp động
    /// </summary>
    public class DynamicClassFactor
    {
        public string DynamicClassID { get; set; }
        public int? FromDynamic { get; set; }
        public int? ToDynamic { get; set; }
        /// <summary>
        /// hệ số
        /// </summary>
        public double Coefficient { get; set; }
        public string TeachesForm { get; set; }
    }
}
