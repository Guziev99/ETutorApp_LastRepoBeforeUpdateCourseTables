using E_TutorApp.Domain.Entities.Concretes;
using E_TutorApp.Persistence.Db_Contexts;
using E_TutorApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace E_TutorApp.Web.Controllers
{
    [Authorize(Roles ="Student")]
    public class HomeController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<HomeController> _logger;
        private TutorDbContext _context;

        public HomeController(ILogger<HomeController> logger, SignInManager<User> signInManager, UserManager<User> userManager, TutorDbContext context = null)
        {
            _logger = logger;
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
        }

        [AllowAnonymous]
        public async Task < IActionResult> Homepage()
        {
                    var topSellingCourses = _context.Courses
                    .OrderByDescending(c => c.SaleCount)
                    .Take(20)
                    .ToList();

                return View(topSellingCourses);
            
 
        }


        [AllowAnonymous]
        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Index2()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [AllowAnonymous]
        public async Task< IActionResult > LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        [AllowAnonymous]
        public async Task<IActionResult> ConfirmEmail (string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            var result = await _userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
                return RedirectToAction("Login", "Account");
            return View("Error");

        }
    }
}
