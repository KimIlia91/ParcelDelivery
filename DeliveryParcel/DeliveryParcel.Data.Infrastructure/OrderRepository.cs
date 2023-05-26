using DeliveryParcel.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace DeliveryParcel.Data.Infrastructure
{
    /// <summary>
    /// Реализация репозитория заказов.
    /// </summary>
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        /// <summary>
        /// Конструктор класса OrderRepository.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<Order>> GetAllOrdersAsync()
        {
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            var orders = await _context.Orders.Include(o => o.Sender)
                                              .Include(o => o.SenderAddress)
                                                  .ThenInclude(a => a.City)
                                              .Include(o => o.Recipient)
                                              .Include(o => o.RecipientAddress)
                                                  .ThenInclude(a => a.City)
                                              .Include(o => o.Parcel)
                                              .ToListAsync();
            return orders;
        }
    }
}
