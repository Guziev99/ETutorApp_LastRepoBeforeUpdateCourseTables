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
    pattern: "{controller=Home}/{action=Index}/{id?}");

//app.Run();




//var container = app.Services.CreateScope();
//var userManager = container.ServiceProvider.GetRequiredService<UserManager<User>>();
//var roleManager = container.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

//var hasStudentRole = await roleManager.RoleExistsAsync("Student");
//if (!hasStudentRole) await roleManager.CreateAsync(new IdentityRole { Name = "Student" });
//var hasInstructorRole = await roleManager.RoleExistsAsync("Instructor");
//if (!hasInstructorRole) await roleManager.CreateAsync(new IdentityRole { Name = "Instructor" });
//var hasAdminRole = await roleManager.RoleExistsAsync("Admin");
//if (!hasAdminRole) await roleManager.CreateAsync(new IdentityRole { Name = "Admin" });


//var AdminUser = await userManager.FindByNameAsync("MahammadAdmin");
//if (AdminUser is null)
//{
//    var result = await userManager.CreateAsync(new User()
//    {
//        UserName = "MahammadAdmin",
//        Email = "MahammadAdmin@gmail.com",
//        EmailConfirmed = true,

//    }, "Admin123#");
//    if (result.Succeeded)
//    {
//        var admin = await userManager.FindByNameAsync("MahammadAdmin");
//        await userManager.AddToRoleAsync(admin, "Admin");
//    }
//}

//var StudentUser = await userManager.FindByNameAsync("MahammadStudent");
//if (StudentUser is null)
//{
//    var result = await userManager.CreateAsync(new User()
//    {
//        UserName = "MahammadStudent",
//        Email = "MahammadStudent@gmail.com",
//        EmailConfirmed = true,

//    }, "Student123#");
//    if (result.Succeeded)
//    {
//        var student = await userManager.FindByNameAsync("MahammadStudent");
//        await userManager.AddToRoleAsync(student, "Student");
//    }
//}

//var InstructorUser = await userManager.FindByNameAsync("MahammadInstructor");
//if (InstructorUser is null)
//{
//    var result = await userManager.CreateAsync(new User()
//    {
//        UserName = "MahammadInstructor",
//        Email = "MahammadInstructor@gmail.com",
//        EmailConfirmed = true,

//    }, "Instructor123#");
//    if (result.Succeeded)
//    {
//        var instructor = await userManager.FindByNameAsync("MahammadInstructor");
//        await userManager.AddToRoleAsync(instructor, "Instructor");
//    }
//}










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