using E_TutorApp.Application.Repositories.CategoryRepos;
using E_TutorApp.Application.Services;
using E_TutorApp.Domain.Entities.Concretes;
using E_TutorApp.Domain.Entities.Concretes;
using E_TutorApp.Infrastructure.Services;
using E_TutorApp.Persistence.Db_Contexts;
using E_TutorApp.Persistence.Repositories.CategoryRepos;
using E_TutorApp.Persistence.Validators;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<TutorDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("Default")
));

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IWriteCategoryRepository, WriteCategoryRepository>();
builder.Services.AddScoped<IReadCategoryRepository, ReadCategoryRepository>();



builder.Services.AddIdentity<User, IdentityRole>(option =>
{
    option.User.RequireUniqueEmail = true;
    option.Password.RequireDigit = false;
    option.Password.RequireLowercase = true;
    option.Password.RequiredLength = 6;

    //lockout
    option.Lockout.MaxFailedAccessAttempts = 5;
    option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
    option.Lockout.AllowedForNewUsers = true;
}).AddEntityFrameworkStores<TutorDbContext>()
  .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    //// Cookie settings
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromMinutes(1);

});

builder.Services.AddScoped<IPasswordValidator<User>, E_TutorApp.Persistence.Validators.PasswordValidator>();





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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}");

//app.Run();




var container = app.Services.CreateScope();
var usermanager = container.ServiceProvider.GetRequiredService<UserManager<User>>();
var rolemanager = container.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

var hasStudentRole = await rolemanager.RoleExistsAsync("Student");
if (!hasStudentRole) await rolemanager.CreateAsync(new IdentityRole { Name = "Student" });
var hasInstructorRole = await rolemanager.RoleExistsAsync("Instructor");
if (!hasInstructorRole) await rolemanager.CreateAsync(new IdentityRole { Name = "Instructor" });
var hasAdminRole = await rolemanager.RoleExistsAsync("Admin");
if (!hasAdminRole) await rolemanager.CreateAsync(new IdentityRole { Name = "Admin" });


//var AdminUser = await usermanager.FindByNameAsync("MahammadAdmin");
//if (AdminUser is null)
//{
//    var result = await usermanager.CreateAsync(new User()
//    {
//        UserName = "MahammadAdmin",
//        Email = "mahammadadmin@gmail.com",
//        EmailConfirmed = true,

//    }, "Admin123#");
//    if (result.Succeeded)
//    {
//        var admin = await usermanager.FindByNameAsync("MahammadAdmin");
//        await usermanager.AddToRoleAsync(admin!, "Admin");
//    }
//}

//var StudentUser = await usermanager.FindByNameAsync("MahammadStudent");
//if (StudentUser is null)
//{
//    var result = await usermanager.CreateAsync(new User()
//    {
//        UserName = "MahammadStudent",
//        Email = "mahammadstudent@gmail.com",
//        EmailConfirmed = true,

//    }, "Student123#");
//    if (result.Succeeded)
//    {
//        var student = await usermanager.FindByNameAsync("MahammadStudent");
//        await usermanager.AddToRoleAsync(student, "Student");
//    }
//}

//var InstructorUser = await usermanager.FindByNameAsync("MahammadInstructor");
//if (InstructorUser is null)
//{
//    var result = await usermanager.CreateAsync(new User()
//    {
//        UserName = "MahammadInstructor",
//        Email = "mahammadınstructor@gmail.com",
//        EmailConfirmed = true,

//    }, "Instructor123#");
//    if (result.Succeeded)
//    {
//        var instructor = await usermanager.FindByNameAsync("MahammadInstructor");
//        await usermanager.AddToRoleAsync(instructor, "Instructor");
//    }
//}

//var InstructorUser2 = await usermanager.FindByNameAsync("ShamilInstructor");
//if (InstructorUser2 is null)
//{
//    var result = await usermanager.CreateAsync(new User()
//    {
//        UserName = "ShamilInstructor",
//        Email = "shamilınstructor@gmail.com",
//        EmailConfirmed = true,

//    }, "Instructor123#");
//    if (result.Succeeded)
//    {
//        var instructor = await usermanager.FindByNameAsync("ShamilInstructor");
//        await usermanager.AddToRoleAsync(instructor, "Instructor");
//    }
//}

var ınstructoruser2 = await usermanager.FindByNameAsync("AliInstructor");
if (ınstructoruser2 is null)
{
    var result = await usermanager.CreateAsync(new User()
    {
        UserName = "AliInstructor",
        Email = "AliInstructor@gmail.com",
        EmailConfirmed = true,

    }, "Instructor123#");
    if (result.Succeeded)
    {
        var instructor = await usermanager.FindByNameAsync ("AliInstructor");
        await usermanager.AddToRoleAsync(instructor, "Instructor");
    }
}








// =======================================================================

//var host = builder.Build();

//using (var scope = host.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    try
//    {
//        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
//        // RoleManager kullanarak başlangıç rolleri ekleyin
//        await SeedRoles(roleManager);
//    }
//    catch (Exception ex)
//    {
//        var logger = services.GetRequiredService<ILogger<Program>>();
//        logger.LogError(ex, "An error occurred while seeding the database.");
//    }
//}
//host.Run();

//async Task SeedRoles(RoleManager<IdentityRole> roleManager)
//{
//    var roles = new List<string> { "Admin", "Instructor", "Student" };

//    foreach (var role in roles)
//    {
//        if (!await roleManager.RoleExistsAsync(role))
//        {
//            await roleManager.CreateAsync(new IdentityRole { Name = role });
//        }
//    }
//}












app.Run();    // Bu butun ishlerden sonra verilmelidir.