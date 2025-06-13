using Microsoft.EntityFrameworkCore;
using Nashoca.Application.Commands;
using Nashoca.Domain.Repositories;
using Nashoca.Intrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddMediatR(c => 
    c.RegisterServicesFromAssembly(typeof(CreateVerbCommand).Assembly));


builder.Services.AddDbContext<MainDbContext>(options => 
    options.UseMySql(
        builder.Configuration.GetConnectionString(""), new MySqlServerVersion(new Version(8,0,42))));

builder.Services.AddScoped<IVerbRepository, IVerbRepository>();

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
