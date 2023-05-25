using DeliveryParcel.Data.Interface;
using Microsoft.EntityFrameworkCore;

namespace DeliveryParcel.Data.Infrastructure
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        private readonly ApplicationDbContext _context;

        public OrderRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

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
