using System.ComponentModel.DataAnnotations;

namespace DeliveryParcel.Models
{
    public class OrderCreateVm
    {
        public ClientVm Sender { get; set; } = null!;

        public AddressVm SenderAddress { get; set; } = null!;

        public ClientVm Recipient { get; set; } = null!;

        public AddressVm RecipientAddress { get; set; } = null!;

        public ParcelVm Parcel { get; set; } = null!;

        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Дата отправки")]
        public DateTime ShippingDate { get; set; }
    }
}
