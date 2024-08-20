using E_TutorApp.Domain.Entities.Concretes;
using E_TutorApp.Domain.ViewModels;
using E_TutorApp.Persistence.Db_Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_TutorApp.Web.Controllers
{
    [Authorize(Roles ="Instructor")]
    public class InstructorController : Controller
    {
        private readonly UserManager<User> _userManager;
        private TutorDbContext _context;

        public InstructorController(UserManager<User> userManager, TutorDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IActionResult> InstructorDashboard()
        {
            var instructor = await _userManager.GetUserAsync(User);
            var instructorId = instructor!.Id;


            #region ViewModel kullanmadan View -a veri gonderimi yoluyla
            // //  //  ViewModel Kullanmadan View -a  veri gonderilmesi
            //      var instructorr =  _context.Users
            //.Where(u => u.Id == instructorId).Include(u =>u.DetailOfInstrutctor).ThenInclude(dI => dI.AllCoursesOfInstructor!)
            //.ThenInclude(cb => cb.AdvanceInfos).Select(
            //          u => new
            //          {
            //              u.UserName,
            //              u.Address,
            //              u.Bio,
            //              u.ProfilePicture,
            //               CourseCount = u.DetailOfInstrutctor!.AllCoursesOfInstructor!.Count(),
            //                  RatingScore = u.DetailOfInstrutctor!.AllCoursesOfInstructor!
            //                  .Where(c => c.RatingScore.HasValue && c.RatingScore.Value > 0)
            //                      .Select(c => c.RatingScore.Value)
            //                      //.DefaultIfEmpty(0)
            //                      .Average(),
            //                  StudentCount = u.DetailOfInstrutctor!.AllCoursesOfInstructor
            //                      .SelectMany(c => c.Students)
            //                      .Count(),
            //              Courses = u.DetailOfInstrutctor!.AllCoursesOfInstructor
            //                      .Select(cb => new
            //                      {
            //                          CategoryName = cb.CategoryName,
            //                          Price = cb.Price,
            //                          Title = cb.Title,
            //                          imgUrl = cb.AdvanceInfos!.ThumbnailUrl,
            //                      }).ToList()

            //          }).FirstOrDefault();
            //      return View(instructorr);
            #endregion



            #region ViewModel ile veri gonderilerken
            //    ViewModel Kullanarak View -a veri gonderimi. 
            var instructorr = _context.Users
      .Where(u => u.Id == instructorId).Include(u => u.DetailOfInstrutctor).ThenInclude(dI => dI.AllCoursesOfInstructor!)
      .ThenInclude(cb => cb.AdvanceInfos).Select(
                u => new InstructorProfileViewModel
                {
                    UserName = u.UserName,
                    Title = u.Address,
                    AboutMe = u.Bio,
                    InstructorImg = u.ProfilePicture,
                    CourseCount = u.DetailOfInstrutctor!.AllCoursesOfInstructor!.Count(),
                    RatingScore = u.DetailOfInstrutctor!.AllCoursesOfInstructor!
                        .Where(c => c.RatingScore.HasValue && c.RatingScore.Value > 0)
                            .Select(c => c.RatingScore.Value)
                            //.DefaultIfEmpty(0)
                            .Average(),
                    StudentCount = u.DetailOfInstrutctor!.AllCoursesOfInstructor
                            .SelectMany(c => c.Students)
                            .Count(),
                    Courses = u.DetailOfInstrutctor!.AllCoursesOfInstructor
                            .Select(cb => new CourseViewModel
                            {
                                CategoryName = cb.CategoryName,
                                Price = cb.Price!.Value,
                                Title = cb.Title,
                                ImgUrl = cb.AdvanceInfos!.ThumbnailUrl,
                            }).ToList()

                }).FirstOrDefault();
            return View(instructorr);
            #endregion
        }


        public async Task <IActionResult> AllCoursesOfInstructor()
        {
            var instructor = await _userManager.GetUserAsync (User);
            var instructorId = instructor?.Id;



            //var instructorVm = await _context.CourseBasics.Include(cb => cb.Instructor).ThenInclude(d => d.Instructor).Where(t => t.Id == instructorId)
            //    .Select(cb => new AllCoursesOfInstructorVM
            //    {
            //        CategoryName = cb!.CategoryName,
            //        Title = cb!.Title,
            //        RatingScore = cb!.RatingScore!.Value,
            //        SaleCount = cb!.Students!.Count(),
            //        Price = cb!.Price!.Value,
            //        ImgUrl = cb!.AdvanceInfos!.ThumbnailUrl!

            //    }).ToListAsync();

            //var instructorVm = await _context.Users.Where(u => u.Id == instructorId)
            //    .Include(u => u.DetailOfInstrutctor).ThenInclude(i => i.AllCoursesOfInstructor).ThenInclude(cb => cb.AdvanceInfos)
            //    .Select(u => u.DetailOfInstrutctor.AllCoursesOfInstructor.Select(c => new AllCoursesOfInstructorVM
            //    {
            //        CategoryName = c.CategoryName,
            //        ImgUrl = c.AdvanceInfos.ThumbnailUrl,
            //        Price = c.Price.Value,
            //        RatingScore = c.RatingScore.Value,
            //        SaleCount = c.SaleCount,
            //        Title = c.Title
            //    })).ToListAsync();
            //return View(instructorVm);


            var courses = await _context.CourseBasics
       .Where(cb => cb.Instructor.InstructorId == instructorId)
       .Select(cb => new AllCoursesOfInstructorVM
       {
           CategoryName = cb.CategoryName, 
           Price = cb.Price.Value,
           RatingScore = cb.RatingScore.Value,
           SaleCount = cb.SaleCount,
           Title = cb.Title,
           ImgUrl = cb!.AdvanceInfos!.ThumbnailUrl!
       }).ToListAsync();

            return View(courses);


            
        }









        }
    }
