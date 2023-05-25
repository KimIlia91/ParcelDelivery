namespace DeliveryParcel.Models
{
    public class OperationResponse<TEntity>
    {
        public bool IsSuccess { get; set; }

        public TEntity? Result { get; set; }

        public string? Errors { get; set; }
    }
}
