using System.ComponentModel.DataAnnotations;

namespace DeliveryParcel.Models
{
    /// <summary>
    /// Модель для создания заказа.
    /// </summary>
    public class OrderCreateVm
    {
        /// <summary>
        /// Информация об отправителе.
        /// </summary>
        public ClientVm Sender { get; set; } = null!;

        /// <summary>
        /// Адрес отправителя.
        /// </summary>
        public AddressVm SenderAddress { get; set; } = null!;

        /// <summary>
        /// Информация о получателе.
        /// </summary>
        public ClientVm Recipient { get; set; } = null!;

        /// <summary>
        /// Адрес получателя.
        /// </summary>
        public AddressVm RecipientAddress { get; set; } = null!;

        /// <summary>
        /// Информация о посылке.
        /// </summary>
        public ParcelVm Parcel { get; set; } = null!;

        /// <summary>
        /// Дата отправки. Обязательное поле.
        /// </summary>
        [Required(ErrorMessage = "Обязательное поле")]
        [Display(Name = "Дата отправки")]
        [DataType(DataType.Date)]
        public DateTime ShippingDate { get; set; }
    }
}
