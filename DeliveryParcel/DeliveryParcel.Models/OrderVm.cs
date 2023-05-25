using System.ComponentModel.DataAnnotations;

namespace DeliveryParcel.Models
{
    public class OrderVm
    {
        [Display(Name = "ID заказа")]
        public Guid Id { get; set; }

        [Display(Name = "Ф.И.О. отправителя")]
        public string SenderFullName { get; set; } = null!;

        [Display(Name = "Адрес отправителя")]
        public string SenderFullAddress { get; set; } = null!;

        [Display(Name = "Город отправителя")]
        public string SenderCity { get; set; } = null!;

        [Display(Name = "Ф.И.О. получателя")]
        public string RecipientFullName { get; set; } = null!;

        [Display(Name = "Адрес получателя")]
        public string RecipientFullAddress { get; set; } = null!;

        [Display(Name = "Город получателя")]
        public string RecipientCity { get; set; } = null!;

        [Display(Name = "Вес посылки")]
        public ParcelVm Parcel { get; set; } = new ParcelVm();

        [Display(Name = "Дата отправки")]
        public DateTime ShippingDate { get; set; }
    }
}
