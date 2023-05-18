using Microsoft.EntityFrameworkCore;
using S3Project.IRepository;
using S3Project.Models;
using S3Project.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddTransient<IVisitorInfoRepository, VisitorInfoRepository>();
builder.Services.AddTransient<IDataRepository, DataRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=VisitorInfo}/{action=create}/{id?}");

app.Run();
