using DeliveryParcel.Models;

namespace DeliveryParcel.Service.Interfaces
{
    /// <summary>
    /// Интерфейс сервиса города.
    /// </summary>
    public interface ICityService
    {
        /// <summary>
        /// Получить ID города по наименованию города.
        /// </summary>
        /// <param name="cityName">Напименование города.</param>
        /// <returns>Ответ <see cref="OperationResponse{TEntit}"/>c идентификатором города если город существует в контексте БД.</returns>
        Task<OperationResponse<Guid>> GetCityIdByNameAsync(string cityName);

        /// <summary>
        /// Создать город.
        /// </summary>
        /// <param name="cityName">Наименование города для создания города.</param>
        /// <returns>Ответ <see cref="OperationResponse{TEntity}"/>c идентификатором созданного города.</returns>
        Task<OperationResponse<Guid>> CreateCityAsync(string cityName);
    }
}
