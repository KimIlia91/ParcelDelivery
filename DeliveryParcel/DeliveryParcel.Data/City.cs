namespace DeliveryParcel.Data
{
    /// <summary>
    /// Сущность города.
    /// </summary>
    public class City : BaseEntity
    {
        /// <summary>
        /// Название города.
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
