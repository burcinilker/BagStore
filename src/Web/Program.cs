using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var csIdentity = builder.Configuration.GetConnectionString("AppIdentityDbContext");
var csBagStore = builder.Configuration.GetConnectionString("BagStoreDbContext");
builder.Services.AddDbContext<BagStoreContext>(options => options.UseNpgsql(csBagStore));
builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseNpgsql(csIdentity));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>() //rolleri servislere ekledik
    .AddEntityFrameworkStores<AppIdentityDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();
await app.SeedDataAsync();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
