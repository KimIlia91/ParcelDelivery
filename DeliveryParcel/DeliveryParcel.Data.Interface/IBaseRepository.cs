using System.Linq.Expressions;

namespace DeliveryParcel.Data.Interface
{
    /// <summary>
    /// Интерфейс базового репозитория.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Получает все сущности асинхронно.
        /// </summary>
        /// <param name="filter">Выражение для фильтрации сущностей (опционально).</param>
        /// <param name="includeProperty">Строка, указывающая связанные свойства, которые должны быть включены (опционально).</param>
        /// <returns>Коллекция сущностей.</returns>
        Task<IEnumerable<TEntity>> GetAllEntitiesAsync(Expression<Func<TEntity, bool>>? filter = null, 
                                                       string? includeProperties = null);

        /// <summary>
        /// Получает сущность или значение по умолчанию асинхронно.
        /// </summary>
        /// <param name="filter">Выражение для фильтрации сущности.</param>
        /// <param name="tracked">Указывает, нужно ли отслеживать изменения сущности (по умолчанию false).</param>
        /// <param name="includeProperties">Строка, указывающая связанные свойства, которые должны быть включены (опционально).</param>
        /// <returns>Сущность или значение по умолчанию.</returns>
        Task<TEntity?> GetEnttyOrDeafaultAsync(Expression<Func<TEntity, bool>> filter,
                                               bool tracked = true,
                                               string? includeProperties = null);

        /// <summary>
        /// Добавляет сущность и асинхронно сохраняет её.
        /// </summary>
        /// <param name="entity">Сущность для добавления.</param>
        Task AddEntityAsync(TEntity entity);

        /// <summary>
        /// Обновляет сущность и асинхронно сохраняет её.
        /// </summary>
        /// <param name="entity">Сущность для обновления.</param>
        Task UpdateEntityAsync(TEntity entity);

        /// <summary>
        /// Удаляет сущность и асинхронно сохраняет её.
        /// </summary>
        /// <param name="entity">Сущность для удаления.</param>
        Task DeleteEntityAsync(TEntity entity);
    }
}