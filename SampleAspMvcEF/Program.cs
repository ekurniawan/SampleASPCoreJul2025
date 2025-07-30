using Microsoft.EntityFrameworkCore;
using SampleAspMvcEF.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//add ef db context
builder.Services.AddDbContext<AutomotiveDB3Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("AutomotiveDBConnectionString")));
builder.Services.AddScoped<ICar, CarDAL>();
builder.Services.AddScoped<IDealerCar, DealerCarDAL>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
