using HandsOnLab.DAL;
using Microsoft.EntityFrameworkCore;
using HandsOnLab.BL.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

//add entity framework
builder.Services.AddDbContext<AutomotiveDB3Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AutomotiveDBConnectionString")));

//add business layer services
builder.Services.AddBusinessLayerServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
