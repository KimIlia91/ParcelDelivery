namespace DeliveryParcel.Models
{
    /// <summary>
    /// Ответ операции.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности, содержащейся в ответе.</typeparam>
    public class OperationResponse<TEntity>
    {
        /// <summary>
        /// Указывает, успешна ли операция.
        /// </summary>
        public bool IsSuccess { get; set; }

        /// <summary>
        /// Результат операции.
        /// </summary>
        public TEntity? Result { get; set; }

        /// <summary>
        /// Ошибки, возникшие в результате операции.
        /// </summary>
        public string? Errors { get; set; }
    }
}
