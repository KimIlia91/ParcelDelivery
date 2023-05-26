using System.ComponentModel.DataAnnotations;

namespace DeliveryParcel.Data
{
    /// <summary>
    /// Сущность заказа.
    /// </summary>
    public class Order : BaseEntity
    {
        /// <summary>
        /// ID отправителя.
        /// </summary>
        public Guid SenderId { get; set; }

        /// <summary>
        /// ID адреса отправителя.
        /// </summary>
        public Guid SenderAddressId { get; set; }

        /// <summary>
        /// ID получателя.
        /// </summary>
        public Guid RecipientId { get; set; }

        /// <summary>
        /// ID адреса получателя.
        /// </summary>
        public Guid RecipientAddressId { get; set; }

        /// <summary>
        /// ID посылки.
        /// </summary>
        public Guid ParcelId { get; set; }

        /// <summary>
        /// Дата отправки.
        /// </summary>
        public DateTime ShippingDate { get; set; }

        /// <summary>
        /// Связь с сущностью отправитель.
        /// </summary>
        public Client Sender { get; set; } = null!;

        /// <summary>
        /// Связь с сущностью получатель.
        /// </summary>
        public Client Recipient { get; set; } = null!;

        /// <summary>
        /// Связь с сущностью послыка.
        /// </summary>
        public Parcel Parcel { get; set; } = null!;

        /// <summary>
        /// Связь с сущностью адреса отправителя.
        /// </summary>
        public Address SenderAddress { get; set; } = null!;

        /// <summary>
        /// Связь с сущностью адреса получателя.
        /// </summary>
        public Address RecipientAddress { get; set; } = null!;
    }
}
