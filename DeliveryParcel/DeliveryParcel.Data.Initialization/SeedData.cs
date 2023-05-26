using DeliveryParcel.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DeliveryParcel.Data.Initialization
{
    /// <summary>
    /// Класс для заполнения начальных данных в базе данных.
    /// </summary>
    public static class SeedData
    {
        /// <summary>
        /// Инициализация начальных данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        public static async Task Initialize(ApplicationDbContext context)
        {
            if (!context.Clients.Any())
                await AddCilentsAsync(context);

            if (!context.Cities.Any())
                await AddCitiesAsync(context);

            if (!context.Addresses.Any())
                await AddAddressesAsync(context);

            if (!context.Parcels.Any())
                await AddParselsAsync(context);

            if (!context.Orders.Any())
                await AddOrdersAsync(context);
        }

        /// <summary>
        /// Добавляет заказы в базу данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        private static async Task AddOrdersAsync(ApplicationDbContext context)
        {
            var orders = new List<Order>
            {
                new Order
                {
                    SenderId = await GetClientIdAsync(context, "Куттубек"),
                    SenderAddressId = await GetAddressIdAsync(context, "Киевская"),
                    RecipientId = await GetClientIdAsync(context, "Мария"),
                    RecipientAddressId = await GetAddressIdAsync(context, "Кучукова Иса"),
                    ParcelId = await GetParcelIdAsync(context, 1.5m),
                    ShippingDate = DateTime.Now
                },
                new Order
                {
                    SenderId = await GetClientIdAsync(context, "Мария"),
                    SenderAddressId = await GetAddressIdAsync(context, "Кучукова Иса"),
                    RecipientId = await GetClientIdAsync(context, "Куттубек"),
                    RecipientAddressId = await GetAddressIdAsync(context, "Киевская"),
                    ParcelId = await GetParcelIdAsync(context, 2.0m),
                    ShippingDate = DateTime.Now
                },
            };
            await context.Orders.AddRangeAsync(orders);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Добавляет послыки в базу данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        private static async Task AddParselsAsync(ApplicationDbContext context)
        {
            var parcels = new List<Parcel>
            {
                new Parcel { Weight = 1.5m, CreatedDate = DateTime.UtcNow },
                new Parcel { Weight = 2.0m, CreatedDate = DateTime.UtcNow },
            };
            await context.Parcels.AddRangeAsync(parcels);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Добавляет клиентов в базу данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        private static async Task AddCilentsAsync(ApplicationDbContext context)
        {
            var clients = new List<Client>
                {
                    new Client { FirstName = "Куттубек", LastName = "Куттубеков", MiddleName = "Куттубекович" },
                    new Client { FirstName = "Мария", LastName = "Маринова" },
                };
            await context.Clients.AddRangeAsync(clients);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Добавляет города в базу данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        private static async Task AddCitiesAsync(ApplicationDbContext context)
        {
            var cities = new List<City>
            {
                new City { Name = "Бишкек", CreatedDate = DateTime.UtcNow },
                new City { Name = "Каракол", CreatedDate = DateTime.UtcNow },
            };
            await context.Cities.AddRangeAsync(cities);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Добавляет адреса в базу данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        private static async Task AddAddressesAsync(ApplicationDbContext context)
        {
            var addresses = new List<Address>
            {
                new Address { Street = "Киевская", House = "199", Flat = 3, Appartament = "46а", CityId = await GetCityIdAsync(context, "Бишкек") },
                new Address { Street = "Кучукова Иса", House = "5", Flat = 1, CityId = await GetCityIdAsync(context, "Каракол") },
            };
            await context.Addresses.AddRangeAsync(addresses);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Получение идентификатора города из базы данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <returns>Случайный идентификатор города.</returns>
        private static async Task<Guid> GetCityIdAsync(ApplicationDbContext context, string cityName)
        {
            var cities = await context.Cities.FirstAsync(c => c.Name == cityName);
            return cities.Id;
        }

        /// <summary>
        /// Получение идентификатора клиента из базы данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <returns>Случайный идентификатор клиента.</returns>
        private static async Task<Guid> GetClientIdAsync(ApplicationDbContext context, string firstName)
        {
            var clients = await context.Clients.FirstAsync(c => c.FirstName == firstName);
            return clients.Id;
        }

        /// <summary>
        /// Получение идентификатора адреса из базы данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <returns>Случайный идентификатор адреса.</returns>
        private static async Task<Guid> GetAddressIdAsync(ApplicationDbContext context, string street)
        {
            var addresses = await context.Addresses.FirstAsync(a => a.Street == street);
            return addresses.Id;
        }

        /// <summary>
        /// Получение идентификатора посылки из базы данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <returns>Случайный идентификатор посылки.</returns>
        private static async Task<Guid> GetParcelIdAsync(ApplicationDbContext context, decimal weight)
        {
            var parcels = await context.Parcels.FirstAsync(p => p.Weight == weight);
            return parcels.Id;
        }
    }
}