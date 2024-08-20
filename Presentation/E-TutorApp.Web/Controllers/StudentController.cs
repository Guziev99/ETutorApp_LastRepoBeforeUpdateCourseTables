using E_TutorApp.Application.Repositories.CategoryRepos;
using E_TutorApp.Domain.Entities.Concretes;
using E_TutorApp.Domain.ViewModels;
using E_TutorApp.Domain.ViewModels.CourseVMs;
using E_TutorApp.Persistence.Db_Contexts;
using E_TutorApp.Persistence.Repositories.CategoryRepos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace E_TutorApp.Web.Controllers
{
    public class StudentController : Controller
    {

        private readonly UserManager<User> _userManager;
        private TutorDbContext _context;
        private IWriteCategoryRepository _writeCategoryRepository;

        public StudentController(UserManager<User> userManager, TutorDbContext context, IWriteCategoryRepository writeCategoryRepository)
        {
            _userManager = userManager;
            _context = context;
            _writeCategoryRepository = writeCategoryRepository;
        }

        [HttpGet]
        public async Task< IActionResult> StudentDashboard()
        {

            #region   Data Insert TO DB
            //Add Category to DB
            //var categories = new List<Category>() {
            //    new Category () {Name = "Web Development", Description ="Programming"},
            //    new Category() {Name = "Design", Description = "About Design"}
            //};
            //await _context.Categories.AddRangeAsync(categories);
            //await _context.SaveChangesAsync();


            //Add InstructorDetail and StudentDetail to DB
            //var instructorDetail = new DetailInstructor()
            //{
            //    InstructorId = "378f6f21-7886-4817-bd32-37b65ea926b8",
            //    Instructor = await _context.Users.FirstOrDefaultAsync(u => u.Id == "378f6f21-7886-4817-bd32-37b65ea926b8"),  
            //};
            //await _context.DetailInstructors.AddAsync(instructorDetail);
            //await _context.SaveChangesAsync();
            //var studentDetail = new DetailStudent()
            //{
            //    StudentId = "bce52de8-743d-4003-91ef-1548994411ca",
            //    Student = await _context.Users.FirstOrDefaultAsync(u => u.Id == "bce52de8-743d-4003-91ef-1548994411ca"),  
            //};
            //await _context.DetailStudents.AddAsync(studentDetail);
            //await _context.SaveChangesAsync();


            //Course Basic Infos to DB
            //var courseBasicInfos = new CourseBasicInfos()
            //{
            //    Id = "ilkCourseBasic",
            //    CategoryName = "Web Development",
            //    SubCategoryName = "Asp .Net",
            //    Title = ".Net Programming full course",
            //    Subtitle = "Web Api and MVC in .Net",
            //    Language = "Aze",
            //    SubtitleLanguage = "en",
            //    Duration = "12",
            //    DurationUnit = "hour",
            //    Topic = "Mamed's programming",
            //    InstructorId = "09c0363f-5f29-4e6d-8970-c8656dd48200",
            //    Level = "Beginner",
            //    Price = 89,
            //    CategoryId = "23bcea0e-3a5d-42b4-9662-44a17c4863cf",
            //    Category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == "Web Development"),
            //    Instructor = await _context.DetailInstructors.FirstOrDefaultAsync(d => d.Id == "09c0363f-5f29-4e6d-8970-c8656dd48200"),
            //};


            // await _context.CourseBasics.AddAsync(courseBasicInfos);
            // await _context.SaveChangesAsync();




            //// Kurs bilgilerini tanımla
            //var courseBasicInfos = new List<CourseBasicInfos>();
            //var categories = new[] { "Web Development", "Design", "Machine Learning", "Cloud Computing" };
            //var subCategories = new[] { "Asp .Net", "Python", "AI", "Azure" };
            //var levels = new[] { "Beginner", "Intermediate", "Advanced" };

            //var catIds = new[] { "Beginner", "Intermediate", "Advanced" };

            //for (int i = 0; i < 10; i++)
            //{
            //    var categoryName = categories[i % categories.Length];
            //    var subCategoryName = subCategories[i % subCategories.Length];
            //    var level = levels[i % levels.Length];

            //    var cat =  _context.Categories.FirstOrDefault(c => c.Name == categoryName);
            //    courseBasicInfos.Add(new CourseBasicInfos
            //    {
            //        Id = $"{i}ciCourseBasicId",
            //        CategoryName = categoryName,
            //        SubCategoryName = subCategoryName,
            //        Title = $"{subCategoryName} Course {i + 1}",
            //        Subtitle = $"Subtitle for {subCategoryName} {i + 1}",
            //        Language = "Aze",
            //        SubtitleLanguage = "en",
            //        Duration = (10 + i).ToString(),
            //        DurationUnit = "hour",
            //        Topic = $"Topic {i + 1}",
            //        InstructorId = $"09c0363f-5f29-4e6d-8970-c8656dd48200",
            //        Level = level,
            //        Price = 50 + i * 5,
            //        CategoryId = "7a03c94d-6bdb-4b71-b05a-65a28b130d13",  // cat.Id,
            //        Instructor = await _context.DetailInstructors.FirstOrDefaultAsync(d => d.Id == "09c0363f-5f29-4e6d-8970-c8656dd48200")
            //    }); ;
            //}

            //// Verileri ekle
            //_context.CourseBasics.AddRange(courseBasicInfos);
            //_context.SaveChanges();



            //var studentDetail = await _context.DetailStudents.FirstOrDefaultAsync(s => s.Id == "9949fe9f-5fa6-48ff-a4bc-27731340f78c");
            //var course = await _context.CourseBasics.FirstOrDefaultAsync(c => c.Id == "2dd2216f-3f10-4d0f-8dda-96d847a6e3cc");
            //course!.Students!.Append(studentDetail);
            //_context.CourseBasics.Update(course);
            //await _context.SaveChangesAsync();


            // Course Advance Infos to DB
            //var courseAdvanceInfos = new CourseAdvanceInfos()
            //{
            //    BasicInfosId = "ilkCourseBasic",
            //    ThumbnailUrl = "data:image/jpeg;base64,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",
            //    Description = "All infos about .net programming",
            //    Trailer = "/videos/video1.mp4",
            //};
            // await _context.CourseAdvances.AddAsync(courseAdvanceInfos);
            // await _context.SaveChangesAsync();


            //var courseBasicInfos = await _context.CourseBasics.ToListAsync();

            //// CourseAdvanceInfos verilerini tanımla
            //var courseAdvanceInfos = new List<CourseAdvanceInfos>();

            //for (int i = 1; i < 10; i++)
            //{
            //    //var basicInfo = courseBasicInfos[i % courseBasicInfos.Count]; // Random bir CourseBasicInfos nesnesi seç
            //    var basicInfo = courseBasicInfos[i];

            //    courseAdvanceInfos.Add(new CourseAdvanceInfos
            //    {
            //        BasicInfosId = basicInfo.Id.ToString(), // CourseBasicInfos ile ilişkilendirme
            //        ThumbnailUrl = $"data:image/png;base64,iVBORw0KGgoAAAANSUhEUgAAAAUAAAAFCAYAAACNbyblAAAAHElEQVQI12P4//8/w38GIAXDIBKE0DHxgljNBAAO9TXL0Y4OHwAAAABJRU5ErkJggg==",
            //        Description = $"All infos about {basicInfo.Title}",
            //        Trailer = "/videos/video" + (i + 1) + ".mp4"
            //    });
            //}

            //// Verileri ekle
            //await _context.CourseAdvances.AddRangeAsync(courseAdvanceInfos);
            //await _context.SaveChangesAsync();


            #endregion




            var user =  await _userManager.GetUserAsync(User);
            var userId = user!.Id;
            //var userDetail = _context.
            //var instructordetail = _context.DetailInstructors.Where(i => i.InstructorId.Contains(userId))!.FirstOrDefault();

            //var enrolledCourses =  _context.Courses.Where(c => c.Students!.Any(s => s.Id.Contains( user!.Id))).ToList();
             //var enrolledCourses = _context.CourseBasics.Where(c => c.Students!.All(s => s.Id.Contains(userId))).ToList();

            var enrolledCourses =  _context.Users
    .Where(u => u.Id == userId)
    .Include(u => u.DetailStudent )
        .ThenInclude(sd => sd.EnrolledCoursesOfStudent)
    .SelectMany(u => u.DetailStudent.EnrolledCoursesOfStudent)
    .ToList();

            //var teachers = user.DetailOfStudent.EnrolledCourses.Where(c=> c.InstructorId .Contains(userId)).ToList();
            // Studentin hocalarinin listesni bula bilmekchun bu yuxaridaki setirdeki kodu edit ede bilerem. 



            //var c = await _context.Users.AnyAsync(s => s.Id == userId);
            //var enrolledCourses = _context.Courses.Find(c);

            //var completedCourses = enrolledCourses.Where(c => c.Status == CourseStatus.Completed).ToList();
            //var activeCourses = enrolledCourses.Where(c => c.Status == CourseStatus.Active).ToList();
            var completedCourses = enrolledCourses.Where(c => c.IsActive == false).ToList();
            var activeCourses = enrolledCourses.Where(c => c.IsActive == true).ToList();

           

            var model = new StudentDashboardVM
            {
                EnrolledCourseCount = enrolledCourses.Count,
                CompletedCourseCount = completedCourses.Count,
                ActiveCourseCount = activeCourses.Count,
                Courses = enrolledCourses
            };

            return View(model);
        }



        public async Task< IActionResult> StudentCourses(string? courseName = null, bool? latest = false, string? teacherName = null  )
        {
            //  Navbardaki Courses tiklandigda da bu calishsin. 
            // Hem de student sechim etdikde ( course ismini yazdigda, teachere gore axtardigda ve s )  yene bu action tetiklensin. 
            // Yuxaridaki latest parametresini buraya gondermeye ehtiyyac yoxdu. View terefdece yoxlanish edib hell edilmelidir dushunurem. 

            var user = await _userManager.GetUserAsync(User);
            var userId = user!.Id;






            //var enrolledCourses1 =  _context.CourseBasics.Where(c => c!.Students!.All(s => s.Student.Id.Contains( userId)))!.ToList()!;
            //var enrolledCourses1 = _context.CourseBasics.Where(c => c.Students!.All(s => s.Id.Contains("9949fe9f-5fa6-48ff-a4bc-27731340f78c"))).ToList();


            var enrolledCourses = _context.Users
    .Where(u => u!.Id == userId!)!
    .Include(u => u!.DetailStudent)!
        .ThenInclude(sd => sd!.EnrolledCoursesOfStudent)!.ThenInclude(bi => bi.AdvanceInfos)
    .SelectMany(u => u!.DetailStudent!.EnrolledCoursesOfStudent!)!
    .ToList();


            //var dStud = await _context.DetailStudents!.FirstOrDefaultAsync(ds => ds!.Student!.Id == userId);
            //var encours = await _context.CourseBasics.FirstOrDefaultAsync(c => c!.Students!.Any(s => s!.Id!.Contains(dStud!.Id)));


            //var course =  _context.CourseBasics .FirstOrDefault();
            //enrolledCourses.Add(course);






            if (!string.IsNullOrEmpty(courseName))
            {
                var coursesOnCourseName = enrolledCourses.FindAll(c => c.Subtitle.Contains(courseName));
                if (!string.IsNullOrEmpty(teacherName))
                {
                    var teacher = await _context.Users.FirstOrDefaultAsync(i => i.UserName == teacherName);
                    var CoursesOnTeacher = coursesOnCourseName.FindAll(c => c.InstructorId == teacher!.Id);
                    var viewModel1 = new CoursesViewModel
                    {
                        CourseName = courseName,
                        Filter = teacherName,
                        Courses = CoursesOnTeacher.ToList()
                    };
                    return View(viewModel1);
                }
                var viewModel2 = new CoursesViewModel
                {
                    CourseName = courseName,
                    Filter = teacherName,
                    Courses = coursesOnCourseName.ToList()
                };
                return View(viewModel2);
            }
            
            if (!string.IsNullOrEmpty(teacherName))
            {
                var teacher = await _context.Users.FirstOrDefaultAsync(i => i.UserName == teacherName);
                var CoursesOnTeacher = enrolledCourses!.FindAll(c => c.InstructorId == teacher!.Id);
                var viewModel3 = new CoursesViewModel
                {
                    CourseName = courseName,
                    Filter = teacherName,
                    Courses = CoursesOnTeacher.ToList()
                };
                return View(viewModel3);
                
            }

            //var model = await _context.CourseBasics!.FirstOrDefaultAsync()!;
            //var k = await _context.CourseAdvances!.FirstOrDefaultAsync();
           // var mm = model!.AdvanceInfos!;


            var viewModel = new CoursesViewModel
            {
                CourseName = courseName,
                Filter = teacherName,
                Courses = enrolledCourses!.ToList()
            };
            return View(viewModel);




            //if (!string.IsNullOrEmpty(filter))
            //{
            //    switch (filter)
            //    {
            //        case "Latest":
            //            filteredCourses = filteredCourses.OrderByDescending(c => c.Id); // Assuming Id represents the creation order
            //            break;
            //        case "AllCourses":
            //            // No additional filtering needed for AllCourses
            //            break;
            //        case "AllTeachers":
            //            // Implement logic to filter by teachers if needed
            //            break;
            //    }



                //if ( courseName == null & teacherName != null ) 
                //{
                //    var teacherId =  _context.Users.Where(t=>t.UserName == teacherName).FirstOrDefault()!.Id;
                //    var courses =   enrolledCourses.Where(c => c.InstructorId == teacherId);

                //    return View(courses);
                //}

                //return View(enrolledCourses);
            }




        public async Task <IActionResult> StudentTeachers(string? Id = null)
        {
            if (!ModelState.IsValid) return View();

            var user = await _userManager.GetUserAsync(User);
            var userId = user!.Id;






            var student = _context.Users
    .Include(u => u.DetailStudent!) // StudentDetail'i include ediyoruz
        .ThenInclude(sd => sd.EnrolledCoursesOfStudent!) // EnrolledCoursesOfStudent'i include ediyoruz
            .ThenInclude(c => c.Instructor!).ThenInclude(d => d.Instructor) // Instructor'ı include ediyoruz
    .FirstOrDefault(u => u.Id == userId)?.DetailStudent;
             
            var instructors = student?.EnrolledCoursesOfStudent?
                .Select(c => c!.Instructor!)
                .Distinct()
                .ToList();

            //var profilePicture = _context.Users.FirstOrDefaultAsync(u => u.Id == instructors.)


            return View(instructors);
        }



    }
}
