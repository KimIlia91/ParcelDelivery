namespace DeliveryParcel.Data
{
    /// <summary>
    /// Сущность адрес.
    /// </summary>
    public class Address : BaseEntity
    {
        /// <summary>
        /// Улица.
        /// </summary>
        public string Street { get; set; } = null!;

        /// <summary>
        /// Номер дома.
        /// </summary>
        public string House { get; set; } = null!;

        /// <summary>
        /// Номер этажа.
        /// </summary>
        public uint Flat { get; set; }

        /// <summary>
        /// Номер квартиры.
        /// </summary>
        public string? Appartament { get; set; }

        /// <summary>
        /// ID города.
        /// </summary>
        public Guid CityId { get; set; }

        /// <summary>
        /// Свойсво навигации для города.
        /// </summary>
        public City City { get; set; } = null!;
    }
}
