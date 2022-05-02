using CommandAPI.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var bul = new NpgsqlConnectionStringBuilder();
bul.ConnectionString = builder.Configuration.GetConnectionString("PostgreSqlConnection");
bul.Username = builder.Configuration["UserID"];
bul.Password = builder.Configuration["Password"];
System.Console.WriteLine(bul.Username);
System.Console.WriteLine(bul.Password);
Console.WriteLine(bul.ConnectionString);

builder.Services.AddDbContext<CommandContext>(opt => opt.UseNpgsql(bul.ConnectionString));

builder.Services.AddControllers();

// builder.Services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>();
builder.Services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
