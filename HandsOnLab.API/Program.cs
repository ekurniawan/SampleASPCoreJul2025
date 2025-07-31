using HandsOnLab.DAL;
using Microsoft.EntityFrameworkCore;
using HandsOnLab.BL.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.PropertyNamingPolicy = null; // Use original property names
});
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//add entity framework
builder.Services.AddDbContext<AutomotiveDB3Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AutomotiveDBConnectionString")));

//add business layer services
builder.Services.AddBusinessLayerServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
