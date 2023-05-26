using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryParcel.Data
{
    public class Parcel : BaseEntity
    {
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Weight { get; set; }
    }
}
