using E_TutorApp.Domain.Entities.Concretes;
using E_TutorApp.Domain.ViewModels;
using E_TutorApp.Persistence.Db_Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_TutorApp.Web.Controllers
{
    public class CourseController : Controller
    {
        private TutorDbContext _context;

        public CourseController(TutorDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CourseDashboard(Course course)
        {
            if(!ModelState .IsValid)  return View(course);

            return View(course);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task <IActionResult> CreateCourseBasicInformation(string? instructorId = null)
        {
            var model = new CourseBasicInfoViewModel
            {
                Categories = new List<string> { "Category 1", "Category 2" },
                SubCategories = new List<string> { "Sub-category 1", "Sub-category 2" },
                Languages = new List<string> { "English", "Turkish" },
                SubtitleLanguages = new List<string> { "English", "Turkish" },
                Levels = new List<string> { "Beginner", "Intermediate", "Advanced" },
                DurationUnits = new List<string> { "Minutes", "Hours", "Days" }
            };

            ViewBag.InstructorId = instructorId;
            return View(model);
            
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task <IActionResult> CreateCourseBasicInformation(CourseBasicInfoViewModel model)
        {


            var course = new Course
            {
                Title = model.Title,
                //Subtitle = model.Subtitle,
                //CategoryId = model.CourseCategory,
                //SubCategory = model.CourseSubCategory,
                //Topic = model.CourseTopic,
                //Language = model.CourseLanguage,
                //SubtitleLanguage = model.SubtitleLanguage,
                //Level = model.CourseLevel,
                //Duration = model.Duration,
                //DurationUnit = model.DurationUnit
                Name = model.CourseTopic,
                Description = model.CourseLevel,
                CategoryId = "ilkCategoryID",
                InstructorId = "ilkInstructorId",


            };
             course.Category = await _context!.Categories!.FirstOrDefaultAsync(c => c.Name == model!.CourseCategory!)!;

            // Course'u veritabanına ekle
            _context.Courses.Add(course);
            _context.SaveChanges();

            // Sonraki adıma yönlendirme
           // return RedirectToAction("AdvancedInformation", new { courseId = course.Id });


            return View("CreateCourseAdvanceInformation", new { courseId = course.Id });
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult CreateCourseAdvanceInformation()
        {
            return View();
        }
    }
}
