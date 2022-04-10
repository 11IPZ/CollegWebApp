using CollegWebApp.DAL;
using CollegWebApp.DAL.Initializes;
using CollegWebApp.DAL.Interfaces;
using CollegWebApp.DAL.Repositories;
using CollegWebApp.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CollegWebAppContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<CollegWebAppContext>();

builder.Services.Configure<IdentityOptions>(options =>
{
    // Password settings.
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;

    // Lockout settings.
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.AllowedForNewUsers = true;

    // User settings.
    options.User.AllowedUserNameCharacters = null;
    options.User.RequireUniqueEmail = true;
});

builder.Services.AddScoped<IGroupRepository, GroupRepository>();
//builder.Services.AddScoped<IUserRepository, UserRepository>();


/*builder.Services.AddTransient<IGroupRepository, GroupRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();

builder.Services.AddScoped<IGroupService, GroupService>();
builder.Services.AddScoped<IUserService, UserService>();*/

var app = builder.Build();

try
{
    using (var serviceScope = app.Services.CreateScope())
    {
        var services = serviceScope.ServiceProvider;

        var userManager = services.GetRequiredService<UserManager<User>>();
        var rolesManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        await RoleInitializer.InitializeAsync(userManager, rolesManager);
    }
}
catch (Exception)
{

    throw;
}


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
