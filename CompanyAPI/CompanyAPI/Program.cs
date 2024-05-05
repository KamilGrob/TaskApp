using testSFD.Interfaces;
using testSFD.Repositories;
using testSFD;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<CompanyDataBaseContext>(options =>
{
    options.UseSqlServer("Server=DESKTOP-QIKQ664;Database=CompanyDataBase;Trusted_Connection=True;TrustServerCertificate=True;");
});

builder.Services.AddTransient<ICarRepository, CarRepository>();
builder.Services.AddTransient<IDriverRepository, DriverRepository>();
builder.Services.AddTransient<ITripRepository, TripRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
