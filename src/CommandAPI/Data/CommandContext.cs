using Microsoft.EntityFrameworkCore;
using CommandAPI.Models;
using Microsoft.EntityFrameworkCore.Design;
using Npgsql;

namespace CommandAPI.Data
{
    public class CommandContext : DbContext
    {
        public CommandContext(DbContextOptions<CommandContext> options)
        : base(options)
        {
        }
        public DbSet<Command> CommandItems { get; set; }
    }

    public class CommandContexttFactory : IDesignTimeDbContextFactory<CommandContext>
    {

        public CommandContext CreateDbContext(string[] args)
        {
            // Get environment
            string environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            // Build config
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../EfDesignDemo.Web"))
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var bul = new NpgsqlConnectionStringBuilder();
            bul.ConnectionString = config.GetConnectionString("PostgreSqlConnection");
            bul.Username = config["UserID"];
            bul.Password = config["Password"];

            // Get connection string
            var optionsBuilder = new DbContextOptionsBuilder<CommandContext>();
            optionsBuilder.UseNpgsql(bul.ConnectionString, b => b.MigrationsAssembly("EfDesignDemo.EF.Design"));
            return new CommandContext(optionsBuilder.Options);
        }
    }
}

