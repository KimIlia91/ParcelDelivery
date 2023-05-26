using DeliveryParcel.Data.Infrastructure;

namespace DeliveryParcel.Data.Initialization
{
    /// <summary>
    /// Класс для заполнения начальных данных в базе данных.
    /// </summary>
    public class SeedData
    {
        /// <summary>
        /// Инициализация начальных данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        public static void Initialize(ApplicationDbContext context)
        {
            if (!context.Cities.Any())
                AddCilents(context);

            if (!context.Addresses.Any())
                AddAddresses(context);

            if (!context.Clients.Any())
                AddCities(context);

            if (!context.Parcels.Any())
                AddParsels(context);

            if (!context.Orders.Any())
                AddOrders(context);
        }

        /// <summary>
        /// Добавляет заказы в базу данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        private static void AddOrders(ApplicationDbContext context)
        {
            var orders = new List<Order>
                {
                    new Order
                    {
                        SenderId = GetRandomClientId(context),
                        SenderAddressId = GetRandomAddressId(context),
                        RecipientId = GetRandomClientId(context),
                        RecipientAddressId = GetRandomAddressId(context),
                        ParcelId = GetRandomParcelId(context),
                        ShippingDate = DateTime.Now
                    },
                    new Order
                    {
                        SenderId = GetRandomClientId(context),
                        SenderAddressId = GetRandomAddressId(context),
                        RecipientId = GetRandomClientId(context),
                        RecipientAddressId = GetRandomAddressId(context),
                        ParcelId = GetRandomParcelId(context),
                        ShippingDate = DateTime.Now
                    },
                };
            context.Orders.AddRange(orders);
            context.SaveChanges();
        }

        /// <summary>
        /// Добавляет послыки в базу данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        private static void AddParsels(ApplicationDbContext context)
        {
            var parcels = new List<Parcel>
                {
                    new Parcel { Weight = 1.5m },
                    new Parcel { Weight = 2.0m },
                };
            context.Parcels.AddRange(parcels);
            context.SaveChanges();
        }

        /// <summary>
        /// Добавляет клиентов в базу данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        private static void AddCilents(ApplicationDbContext context)
        {
            var clients = new List<Client>
                {
                    new Client { FirstName = "Куттубек", LastName = "Куттубеков", MiddleName = "Куттубекович" },
                    new Client { FirstName = "Мария", LastName = "Маринова" },
                };
            context.Clients.AddRange(clients);
            context.SaveChanges();
        }

        /// <summary>
        /// Добавляет города в базу данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        private static void AddCities(ApplicationDbContext context)
        {
            var cities = new List<City>
                {
                    new City { Name = "Бишкек" },
                    new City { Name = "Каракол" },
                };
            context.Cities.AddRange(cities);
            context.SaveChanges();
        }

        /// <summary>
        /// Добавляет адреса в базу данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        private static void AddAddresses(ApplicationDbContext context)
        {
            var addresses = new List<Address>
                {
                    new Address { Street = "Киевская", House = "199", Flat = 3, Appartament = "46а", CityId = GetRandomCityId(context) },
                    new Address { Street = "Кучукова Иса", House = "5", Flat = 1, CityId = GetRandomCityId(context) },
                };
            context.Addresses.AddRange(addresses);
            context.SaveChanges();
        }

        /// <summary>
        /// Получение случайного идентификатора города из базы данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <returns>Случайный идентификатор города.</returns>
        private static Guid GetRandomCityId(ApplicationDbContext context)
        {
            var cities = context.Cities.ToList();
            var randomIndex = new Random().Next(cities.Count);
            return cities[randomIndex].Id;
        }

        /// <summary>
        /// Получение случайного идентификатора клиента из базы данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <returns>Случайный идентификатор клиента.</returns>
        private static Guid GetRandomClientId(ApplicationDbContext context)
        {
            var clients = context.Clients.ToList();
            var randomIndex = new Random().Next(clients.Count);
            return clients[randomIndex].Id;
        }

        /// <summary>
        /// Получение случайного идентификатора адреса из базы данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <returns>Случайный идентификатор адреса.</returns>
        private static Guid GetRandomAddressId(ApplicationDbContext context)
        {
            var addresses = context.Addresses.ToList();
            var randomIndex = new Random().Next(addresses.Count);
            return addresses[randomIndex].Id;
        }

        /// <summary>
        /// Получение случайного идентификатора посылки из базы данных.
        /// </summary>
        /// <param name="context">Контекст базы данных.</param>
        /// <returns>Случайный идентификатор посылки.</returns>
        private static Guid GetRandomParcelId(ApplicationDbContext context)
        {
            var parcels = context.Parcels.ToList();
            var randomIndex = new Random().Next(parcels.Count);
            return parcels[randomIndex].Id;
        }
    }
}