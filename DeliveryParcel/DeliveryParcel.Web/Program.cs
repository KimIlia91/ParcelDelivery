using DeliveryParcel.Data.Infrastructure;
using DeliveryParcel.Data.Initialization;
using DeliveryParcel.Data.Interface;
using DeliveryParcel.Service.Infrastructure;
using DeliveryParcel.Service.Infrastructure.MapperConfiguration;
using DeliveryParcel.Service.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(MapperConfig));

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddTransient<ICityService, CityService>();
builder.Services.AddTransient<IAddressService, AddressService>();
builder.Services.AddTransient<IClientService, ClientService>();
builder.Services.AddTransient<IOrderService, OrderService>();
builder.Services.AddTransient<IParcelService, ParcelService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationDbContext>();
    await SeedData.Initialize(dbContext);
}

app.Run();
