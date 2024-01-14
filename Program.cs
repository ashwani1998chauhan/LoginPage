using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using LoginPage.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("LoginPageContextConnection") ?? throw new InvalidOperationException("Connection string 'LoginPageContextConnection' not found.");

builder.Services.AddDbContext<LoginPageContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<LoginPageUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<LoginPageContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
