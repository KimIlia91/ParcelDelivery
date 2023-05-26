using System.ComponentModel.DataAnnotations;

namespace DeliveryParcel.Models
{
    /// <summary>
    /// Модель представления заказа.
    /// </summary>
    public class OrderVm
    {
        /// <summary>
        /// ID заказа.
        /// </summary>
        [Display(Name = "ID заказа")]
        public Guid Id { get; set; }

        /// <summary>
        /// Ф.И.О. отправителя.
        /// </summary>
        [Display(Name = "Ф.И.О. отправителя")]
        public string SenderFullName { get; set; } = null!;

        /// <summary>
        /// Адрес отправителя.
        /// </summary>
        [Display(Name = "Адрес отправителя")]
        public string SenderFullAddress { get; set; } = null!;

        /// <summary>
        /// Город отправителя.
        /// </summary>
        [Display(Name = "Город отправителя")]
        public string SenderCity { get; set; } = null!;

        /// <summary>
        /// Ф.И.О. получателя.
        /// </summary>
        [Display(Name = "Ф.И.О. получателя")]
        public string RecipientFullName { get; set; } = null!;

        /// <summary>
        /// Адрес получателя.
        /// </summary>
        [Display(Name = "Адрес получателя")]
        public string RecipientFullAddress { get; set; } = null!;

        /// <summary>
        /// Город получателя.
        /// </summary>
        [Display(Name = "Город получателя")]
        public string RecipientCity { get; set; } = null!;

        /// <summary>
        /// Вес посылки.
        /// </summary>
        [Display(Name = "Вес посылки")]
        public string ParcelWeight { get; set; } = null!;

        /// <summary>
        /// Дата отправки.
        /// </summary>
        [Display(Name = "Дата отправки")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime ShippingDate { get; set; }
    }
}
