using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryParcel.Data
{
    /// <summary>
    /// Сущность посылки.
    /// </summary>
    public class Parcel : BaseEntity
    {
        /// <summary>
        /// Вес посылки.
        /// </summary>
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Weight { get; set; }
    }
}
