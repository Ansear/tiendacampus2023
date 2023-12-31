using System.Reflection;
using API.Extension;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAplicationServices();
builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

    builder.Services.AddDbContext<TiendaCampusContext>(options =>
    {
        string  connectionString = builder.Configuration.GetConnectionString("MySqlConex");
        options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    });

var app = builder.Build();
app.UseCors("CorsPolicy");
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
