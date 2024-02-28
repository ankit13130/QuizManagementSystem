using Microsoft.EntityFrameworkCore;
using QuizManagement.Infra.Domain;

namespace QuizManagement.API.Configurations;

public static class SqlServerConfiguration
{
    public static void AddSqlServer(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<QuizContext>(options => options.UseSqlServer(configuration["ConnectionStrings:DefaultConnection"], x => x.MigrationsAssembly("QuizManagement.Infra.Domain")));
    }
}
