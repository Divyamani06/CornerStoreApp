using CornerStore.API.GenericRepository;
using CornerStore.API.Repositories;
using CornerStore.API.Repositories.Interfacese;
using CornerStore.API.Repositories.IRepositories;
using CornerStore.API.Services;
using CornerStore.API.Services.Interfacese;
using CornerStore.API.Services.IServices;

namespace CornerStore.API.AddDependencyInjectionServices
{
    public static class RegisterLocalServices
    {
        public static IServiceCollection APIDependencyInjections(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<ICustomersService, CustomerService>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IShipmentRepository, ShipmentRepository>();
            services.AddScoped<IShipmentService, ShipmentService>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();

            return services;
        }
    }
}
