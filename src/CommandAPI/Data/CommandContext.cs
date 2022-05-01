using Microsoft.EntityFrameworkCore;
using CommandAPI.Models;
using Microsoft.EntityFrameworkCore.Design;

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
            var optionsBuilder = new DbContextOptionsBuilder<CommandContext>();
            optionsBuilder.UseNpgsql("User ID=cmddbuser; Password=pa55w0rd!; Host=localhost; Port=5432; Database=CmdAPI; Pooling=true;");

            return new CommandContext(optionsBuilder.Options);
        }
    }
}

