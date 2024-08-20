using E_TutorApp.Domain.Entities.Concretes;
using E_TutorApp.Domain.ViewModels;
using E_TutorApp.Persistence.Db_Contexts;
using E_TutorApp.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                    var topSellingCourses = _context.CourseBasics
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


        [AllowAnonymous]
        public async Task< IActionResult> Categories()
        {
            var topCourses = _context.CourseBasics 
                .OrderByDescending(c => c.SaleCount)
                .Take(20)
                .Select(c => new CourseBasicInfoViewModel
                {
                    Id = c.Id,
                    Title = c.Title,
                    Subtitle = c.Subtitle,
                    Salecount = c.SaleCount,
                    Rating = c.RatingScore,
                    ImgUrl = c.AdvanceInfos!.ThumbnailUrl,
                    CategoryName = c!.Category!.Name,
                })
                .ToList();
            return View(topCourses);
        }


        [AllowAnonymous]
        public async Task< IActionResult> MainCourse(string Id )
        {
        //    var course = _context.CourseBasics
        //.Include(c => c.Instructor).Include(c => c.AdvanceInfos)
        //.FirstOrDefault(c => c.Id ==  Id);

            var course = await _context.CourseAdvances.Include(a => a.BasicInfos).ThenInclude(b => b.Instructor).
                ThenInclude(i => i.Instructor).FirstOrDefaultAsync(a =>a.BasicInfosId == Id);

            //var instrctr = await _context.Users.FirstOrDefaultAsync(u => u.DetailOfInstrutctor .Contains(course!.InstructorId !));
            var viewModel = new MainCourseVM
            {
                Id =  course!.BasicInfosId,
                Title = course!.BasicInfos!?.Title,
                Subtitle = course!.BasicInfos!?.Subtitle,
                InstructorName = course!.BasicInfos!?.Instructor!?.Instructor?.UserName,
                TrailerVideo =  course!.Trailer,

                Description = course!.Description,
                Requirements = course!.Requirements!?.ToList(),
                //Curriculum = course!.AdvanceInfos!.Curriculum!.Sections!.ToList()!
            };
            
            return View(viewModel);

            
        }



    }
}
