using DeliveryParcel.Data.Interface;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DeliveryParcel.Data.Infrastructure
{
    /// <summary>
    /// Базовый репозиторий.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        /// <summary>
        /// Конструктор класса BaseRepository.
        /// </summary>
        /// <param name="context">Контекст базы данных приложения.</param>
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();

        }
        
        /// <inheritdoc/>
        public async Task AddEntityAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await SaveAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteEntityAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
            await SaveAsync();
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<TEntity>> GetAllEntitiesAsync(Expression<Func<TEntity, bool>>? filter = null, string? includeProperties = null)
        {
            IQueryable<TEntity> query = _dbSet.AsNoTracking();
            if (includeProperties is not null)
                foreach (var includeProp in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProp);

            if (filter is not null)
                query = query.Where(filter);

            return await query.ToArrayAsync();
        }

        /// <inheritdoc/>
        public async Task<TEntity?> GetEnttyOrDeafaultAsync(
            Expression<Func<TEntity, bool>> filter, bool tracked = true, string? includeProperties = null)
        {
            ///TODO: Трекер можно сделать при необходимости
            IQueryable<TEntity> query = _dbSet;
            if (includeProperties is not null)
                foreach (var includeProp in includeProperties.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(includeProp);

            if (filter is not null)
                query = query.Where(filter);

            return await query.FirstOrDefaultAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateEntityAsync(TEntity entity)
        {
            _dbSet.Update(entity);
            await SaveAsync();
        }

        /// <summary>
        /// Сохраняет изменения в контексте базы данных.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Ошибка при сохранении данных в контексте базы данных.</exception>
        private async Task SaveAsync()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Ощибка при сохранении информации в контексте данных.", ex);
            }
        }
    }
}
