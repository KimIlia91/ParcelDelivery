using Microsoft.EntityFrameworkCore;

namespace DeliveryParcel.Data.Infrastructure
{
    /// <summary>
    /// Класс контекста базы данных приложения.
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Коллекция городов.
        /// </summary>
        public DbSet<City> Cities { get; set; }

        /// <summary>
        /// Коллекция адресов.
        /// </summary>
        public DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// Коллекция клиентов.
        /// </summary>
        public DbSet<Client> Clients { get; set; }

        /// <summary>
        /// Коллекция посылок.
        /// </summary>
        public DbSet<Parcel> Parcels { get; set; }

        /// <summary>
        /// Коллекция заказов.
        /// </summary>
        public DbSet<Order> Orders { get; set; }

        /// <summary>
        /// Конструктор класса ApplictionDbContext.
        /// </summary>
        /// <param name="options">Параметры контекста базы данных.</param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}