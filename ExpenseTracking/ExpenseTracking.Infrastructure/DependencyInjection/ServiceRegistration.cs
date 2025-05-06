using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ExpenseTracking.Application;
using ExpenseTracking.Infrastructure.Services;

namespace ExpenseTracking.Infrastructure;

public static class ServiceRegistration
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
    {
        // DbContext
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(config.GetConnectionString("DefaultConnection"))
        );

        // Uygulama katmanındaki interface’leri karşılayan sınıflar
        services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

        // Dosya depolama ve ödeme servisleri
        services.AddScoped<IFileStorageService, FileStorageService>();
        services.AddSingleton<IFakePaymentService, FakePaymentService>(); 
        //services.AddScoped<IFakeBankService, FakeBankService>();

        // Repositories
        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IExpenseRepository, ExpenseRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();
        
        services.AddScoped<IJwtService, JwtService>();

        return services;
    }
}