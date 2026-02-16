// Подключаем Entity Framework Core, чтобы использовать методы для работы с БД
using Microsoft.EntityFrameworkCore;

// Подключаем нашу папку с Data, где лежит ApplicationDbContext
using Task.net.Infrastructure.Data;

// Пространство имен для расширений API
namespace Task.net.API.Extensions;

// static class - класс, который нельзя создать через new, только вызывать методы
// Используется для методов расширения
public static class ServiceExtensions
{
    // Это метод расширения (this IServiceCollection services)
    // Позволяет вызывать services.AddInfrastructure(...) в Program.cs
    // IConfiguration - для доступа к appsettings.json
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        // Добавляем DbContext в контейнер зависимостей (DI)
        // Теперь везде в приложении можно получить ApplicationDbContext
        services.AddDbContext<ApplicationDbContext>(options =>
            // Настраиваем использование SQL Server
            options.UseSqlServer(
                // Берем строку подключения из appsettings.json по имени "DefaultConnection"
                configuration.GetConnectionString("DefaultConnection"),
                // Указываем, где искать миграции (в проекте Infrastructure)
                b => b.MigrationsAssembly("Task.net.Infrastructure")));
    }
}