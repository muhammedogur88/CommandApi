using CommandAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<CommandContext>(opt => opt.UseNpgsql
 (builder.Configuration.GetConnectionString("PostgreSqlConnection")));

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
