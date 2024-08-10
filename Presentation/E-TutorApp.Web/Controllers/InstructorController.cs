using Microsoft.AspNetCore.Mvc;

namespace E_TutorApp.Web.Controllers
{
    public class InstructorController : Controller
    {
        public IActionResult InstructorDashboard()
        {
            return View();
        }
    }
}
