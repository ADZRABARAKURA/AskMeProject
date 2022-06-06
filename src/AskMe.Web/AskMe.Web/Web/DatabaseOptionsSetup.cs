using AskMe.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace AskMe.Web.Web;

internal class DatabaseOptionsSetup
{
    private readonly string connectionString;

    public DatabaseOptionsSetup(string connectionString)
    {
        this.connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
    }

    public void Setup(DbContextOptionsBuilder options)
    {
        options.UseMySql(
            connectionString,
            new MySqlServerVersion(new Version(8, 0, 28)),
            sqlOptions => sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name)
        );
    }
}
