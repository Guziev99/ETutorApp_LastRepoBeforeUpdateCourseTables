using E_TutorApp.Application.Repositories.CategoryRepos;
using E_TutorApp.Domain.DTOs;
using E_TutorApp.Domain.Entities.Concretes;
using E_TutorApp.Domain.ViewModels;
using E_TutorApp.Domain.ViewModels;
using EStore_Persistence.Services;
using Microsoft.AspNetCore.Mvc;

namespace E_TutorApp.Web.Controllers
{
    public class CategoryController : Controller
    {
        private  IWriteCategoryRepository _writeCategoryRepository;
        private readonly IReadCategoryRepository _readCategoryRepository;

        public CategoryController(IWriteCategoryRepository writeCategoryRepository, IReadCategoryRepository readCategoryRepository)
        { 
            _writeCategoryRepository = writeCategoryRepository;
                _readCategoryRepository = readCategoryRepository;
        
        }


        #region AddCategory
        [HttpGet]
        public ActionResult AddCategory() 
        {
            return View();
        }

        [HttpPost]
        public async Task< IActionResult> AddCategory(CategoryVM categoryVM)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var newcategory = new Category()
            {
                Name = categoryVM.Name,
                Description = categoryVM.Description,
                IconUrl = categoryVM.IconUrl

            };
            await _writeCategoryRepository.AddAsync(newcategory);
            await _writeCategoryRepository.SaveChangeAsync();
        
            return RedirectToAction("Login", "Account");
        }
        #endregion


        #region GetAllCategories
        [HttpGet]
        public async Task <IActionResult> AllCategories()
        {
            if (!ModelState.IsValid) return View("Error");

            var categories = await _readCategoryRepository.GetAllAsync();
            //var categoriesOnPages =  PaginationService.Paginate<Category>(categories, new PaginationVM() { Page = 2, PageSize = 3 });
            var categoryVmPages = categories!.Select(c =>
                new CategoryVM()
                {
                    Name = c.Name,
                    Description = c.Description,
                    IconUrl = c.IconUrl
                }  );
            return View(categoryVmPages.ToList());
        }

        #endregion


        #region GetCoursesByCategoryByName

        [HttpGet]
        public  async Task<  IActionResult> CoursesByCategoryName(string?  categoryName = "Web Development")
        {
            
            var courses = await _readCategoryRepository.GetAllCoursesWithCategoryName(categoryName);
               ViewBag .Courses = courses;

            if(courses != null)
            {
                var coursesVm = courses!.Select(c =>
                new CourseDTO()
                {
                    Name = c.Subtitle ,
                    Description = c.AdvanceInfos.Description,
                    ImageUrl = c.AdvanceInfos.ThumbnailUrl,
                    CategoryName = c.CategoryName,
                    InstructorId = c.InstructorId,
                    Price = c.Price,
                    Title = c.Title
                });
                return View(coursesVm.ToList());
            }

            return View();


            
        }

        //[HttpPost]
        //public async Task<IActionResult> GetCoursesByCategoryId(int id)
        //{
        //    var courses = await _readCategoryRepository.GetAllCoursesWithCategoryId(id);

        //    ViewBag .Courses = courses;
        //    return View("AllCoursesThisCategory", courses);
        //}

        //[HttpGet]
        //public async Task <IActionResult> AllCoursesThisCategory(IEnumerable<Course>? courses )
        //{
        //    return View(courses);
        //}



        #endregion




    }
}
