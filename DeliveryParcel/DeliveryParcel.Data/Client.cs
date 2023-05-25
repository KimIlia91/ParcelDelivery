using System.ComponentModel.DataAnnotations.Schema;

namespace DeliveryParcel.Data
{
    public class Client : BaseEntity
    {
        /// <summary>
        /// Имя клиента.
        /// </summary>
        public string FirstName { get; set; } = null!;

        /// <summary>
        /// Фамилия клиента.
        /// </summary>
        public string LastName { get; set; } = null!;

        /// <summary>
        /// Отчество клиента. Опционально.
        /// </summary>
        public string? MiddleName { get; set; }

        /// <summary>
        /// Коллекция заказов клиента.
        /// </summary>
        [NotMapped]
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
