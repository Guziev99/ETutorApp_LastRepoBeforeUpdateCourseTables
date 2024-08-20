using E_TutorApp.Domain.Entities.Concretes;
using Microsoft.AspNetCore.Mvc;

namespace E_TutorApplicationFront.ViewComponents
{
    public class CategoryViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            List<Category> list = new List<Category>()
            {
                new Category{Id = "1" , Name = "Development", IconUrl = ""},
                new Category{Id = "2" , Name = "Business", IconUrl = ""},
                new Category{Id = "3" , Name = "Finance & Accounting", IconUrl = ""},
                new Category{Id = "4" , Name = "IT & Software", IconUrl = ""}
            };

            return View("~/Views/Shared/Components/Category/Default.cshtml", list); 
        }
    }
}
