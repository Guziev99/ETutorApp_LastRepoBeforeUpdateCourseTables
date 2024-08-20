using E_TutorApp.Domain.Entities.Concretes;
using E_TutorApp.Domain.Enums;
using E_TutorApp.Domain.ViewModels;
using E_TutorApp.Domain.ViewModels.AddCurriculumVMs;
using E_TutorApp.Persistence.Db_Contexts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Collections.Specialized.BitVector32;

namespace E_TutorApp.Web.Controllers
{
    public class CourseController : Controller
    {
        private TutorDbContext _context;
        private readonly UserManager<User> _userManager;

        public CourseController(TutorDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> CourseDashboard(CourseBasicInfos course)
        {
            if(!ModelState .IsValid)  return View(course);

            return View(course);
        }

        [Authorize(Roles ="Instructor")]
        [HttpGet]
        public async Task <IActionResult> CreateCourseBasicInformation(string? instructorId = null)
        {
            

            //var model = new CourseBasicInfoViewModel
            //{
            //    Categories = new List<string> { "Category 1", "Category 2" },
            //    SubCategories = new List<string> { "Sub-category 1", "Sub-category 2" },
            //    
            //    SubtitleLanguages = new List<string> { "English", "Turkish" },
            //    Levels = new List<string> { "Beginner", "Intermediate", "Advanced" },
            //    DurationUnits = new List<string> { "Minutes", "Hours", "Days" }
            //};

            //ViewBag.InstructorId = instructorId;




            //ViewBag.Languages = await _context.Languages.Select(l => l.Name).ToListAsync();
            ViewBag.Languages = new List<string> { "English", "Turkish" };
            //ViewBag.SubtitleLanguages = await _context.SubtitleLanguages.Select(sl => sl.Name).ToListAsync();
            ViewBag.SubtitleLanguages = new List<string> { "English", "Turkish" };
            // ViewBag.Subcategories = await _context.Subcategories.Select(sc => sc.Name).ToListAsync();
            ViewBag.SubCategories = new List<string> { "Sub-category 1", "Sub-category 2" };

            ViewBag.Categories = await _context.Categories.Select(c => c.Name).ToListAsync();
           

            // Enum verileri
            ViewBag.Levels = Enum.GetValues(typeof(Level)).Cast<Level>();
            ViewBag.DurationUnits = Enum.GetValues(typeof(DurationUnit)).Cast<DurationUnit>();

            return View();

        }

        [Authorize(Roles ="Instructor")]
        [HttpPost]
        public async Task <IActionResult> CreateCourseBasicInformation(CourseCreateBasicsViewModel model)
        {
            var user = await _userManager.GetUserAsync(User);
            var userId = user!.Id;

            var instructorDetail = user.DetailOfInstrutctor;


            if (!ModelState.IsValid) return View(model);

            var category =  await _context.Categories.FirstOrDefaultAsync(c => c.Name == model.CategoryName);
            var course = new CourseBasicInfos
            {
                //Id = Guid.NewGuid().ToString(),
                Title = model.Title,
                Subtitle = model.Subtitle,
                Topic = model.Topic,
                Duration = model.Duration.ToString(),
                DurationUnit = model.DurationUnit.ToString(),
                Language = model.Language,
                SubtitleLanguage = model.SubtitleLanguage,
                Level = model.Level.ToString(),
                CategoryName = model.CategoryName,
                SubCategoryName = model.SubCategoryName,
                InstructorId = "aliInstructorId",
                //Instructor = instructorDetail,
                Price = 89,
                CategoryId = category!.Id,
                Category = category!
                    
                    
                };


                _context.CourseBasics.Add(course);
                await _context.SaveChangesAsync();


            // Veriler tekrar dolduruluyor hata durumunda
            //ViewBag.Languages = await _context.Languages.Select(l => l.Name).ToListAsync();
            ViewBag.Languages = new List<string> { "English", "Turkish" };
            //ViewBag.SubtitleLanguages = await _context.SubtitleLanguages.Select(sl => sl.Name).ToListAsync();
            ViewBag.SubtitleLanguages = new List<string> { "English", "Turkish" };
            // ViewBag.Subcategories = await _context.Subcategories.Select(sc => sc.Name).ToListAsync();
            ViewBag.SubCategories = new List<string> { "Sub-category 1", "Sub-category 2" };
            ViewBag.Categories = await _context.Categories.Select(c => c.Name).ToListAsync();


            // Enum verileri
            ViewBag.Levels = Enum.GetValues(typeof(Level)).Cast<Level>();
            ViewBag.DurationUnits = Enum.GetValues(typeof(DurationUnit)).Cast<DurationUnit>();

            // Sonraki adıma yönlendirme
            return RedirectToAction("CreateCourseAdvanceInformation", new { courseId = course.Id });
        }


        // GET: Course/CreateAdvance
        [Authorize(Roles = "Instructor")]
        [HttpGet]
        public IActionResult CreateCourseAdvanceInformation(string courseId)
        {
            var model = new CourseAdvanceCreateViewModel
            {
                CourseId = courseId
            };

            return View(model);
        }


        // POST: Course/CreateAdvance
        [Authorize(Roles = "Instructor")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateCourseAdvanceInformation(CourseAdvanceCreateViewModel model, IFormFile ThumbnailImage, IFormFile TrailerVideo)
        {
            if (!ModelState.IsValid) return View(model);

            string? thumbnailUrl = null;
            string? trailerUrl = null;

            // Thumbnail image yüklemesi
            if (ThumbnailImage != null && ThumbnailImage.Length > 0)
            {
                var thumbnailPath = Path.Combine("wwwroot/images/thumbnails", ThumbnailImage.FileName);
                using (var stream = new FileStream(thumbnailPath, FileMode.Create))
                {
                    await ThumbnailImage.CopyToAsync(stream);
                }
                thumbnailUrl = "/images/thumbnails/" + ThumbnailImage.FileName; // ThumbnailUrl için yolu belirle
            }

            // Trailer video yüklemesi
            if (TrailerVideo != null && TrailerVideo.Length > 0)
            {
                var trailerPath = Path.Combine("wwwroot/videos", TrailerVideo.FileName);
                using (var stream = new FileStream(trailerPath, FileMode.Create))
                {
                    await TrailerVideo.CopyToAsync(stream);
                }
                trailerUrl = "/videos/" + TrailerVideo.FileName; // Trailer için yolu belirle
            }

            var courseAdvanceInfos = new CourseAdvanceInfos
            {
                BasicInfosId  = model.CourseId,
                ThumbnailUrl = thumbnailUrl, // Yolu kaydet
                Description = model.Description,
                Trailer = trailerUrl, // Yolu kaydet
                ContentSummary = model.ContentSummary,
                TargetAudience = model.TargetAudience,
                Requirements = model.Requirements
            };

            

            _context.CourseAdvances.Add(courseAdvanceInfos);
            await _context.SaveChangesAsync();

            return RedirectToAction("CreateCurriculum", new { id = courseAdvanceInfos.Id }); // Kurs listesine geri dönme veya başka bir işlem yapabilirsiniz
        }




        [HttpGet]
        public async Task< IActionResult > CreateCurriculum(string courseAdvancesId)
        {
            var model = new CurriculumViewModel
            {
                CourseAdvancesId = courseAdvancesId
            };

            //ViewBag.sections= new List<SectionViewModel>();
           // ViewBag.lectures = new List<LectureViewModel>();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCurriculum(CurriculumViewModel model, IFormFile videoFile, IFormFile attachFile)
        {
            if (ModelState.IsValid)
            {

                string? lessonVideoUrl = null;
                string? lessonAttachmentUrl = null;
                if (videoFile != null && videoFile.Length > 0)
                {
                    var trailerPath = Path.Combine("wwwroot/uploads/videos", videoFile.FileName);
                    using (var stream = new FileStream(trailerPath, FileMode.Create))
                    {
                        await videoFile.CopyToAsync(stream);
                    }
                    lessonVideoUrl = "/videos/" + videoFile.FileName; // Trailer için yolu belirle
                }


                if (attachFile != null && attachFile.Length > 0)
                {
                    var trailerPath = Path.Combine("wwwroot/uploads/attachments", attachFile.FileName);
                    using (var stream = new FileStream(trailerPath, FileMode.Create))
                    {
                        await attachFile.CopyToAsync(stream);
                    }
                    lessonAttachmentUrl = "/videos/" + attachFile.FileName; // Trailer için yolu belirle
                }



                // Curriculum oluşturuluyor
                var curriculum = new CourseCurriculum
                {
                    AdvanceInfosId  = model.CourseAdvancesId,
                    Sections = model.Sections.Select(s => new CourseSection
                    {
                        Name = s.Name,
                        Lectures = s.Lectures.Select(l => new CourseLecture
                        {
                            Name = l.LectureName,
                            VideoUrl = lessonVideoUrl ,  // Video upload ve URL alınıyor
                            AttachFileUrl = lessonAttachmentUrl, // Dosya upload ve URL alınıyor
                            Caption = l.Caption,
                            Description = l.Description,
                            LectureNotes = l.LectureNotes
                        }).ToList()
                    }).ToList()
                };

                // Curriculum, Sections ve Lectures db'ye ekleniyor
                _context.CourseCurriculum.Add(curriculum);
                await _context.SaveChangesAsync();

                return RedirectToAction("Success");
            }
            return View(model);
        }





        private string UploadFile(IFormFile file, string folderPath)
        {
            if (file != null && file.Length > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderPath, fileName);

                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderPath)))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderPath));
                }

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }

                return $"/{folderPath}/{fileName}";
            }

            return null;
        }








        [HttpGet]
        public async Task< IActionResult> CourseIzle(string curId)
        {
            var curriculum = await _context.CourseCurriculum
            .Include(c => c.Sections)
                .ThenInclude(s => s.Lectures)
            .Where(c => c.Id == curId)
            .Select(c => new CurriculumDetailViewModel
            {
                //CurriculumName = c.,
                Sections = c.Sections.Select(s => new SectionDetailViewModel
                {
                    SectionName = s.Name,
                    Lectures = s.Lectures.Select(l => new LectureDetailViewModel
                    {
                        LectureId = l.Id,
                        LectureName = l.Name,
                        VideoUrl = l.VideoUrl,
                        AttachFile = l.AttachFileUrl,
                        Caption = l.Caption,
                        Description = l.Description,
                        LectureNotes = l.LectureNotes
                    }).ToList()
                }).ToList()
            })
            .FirstOrDefaultAsync();

            if (curriculum == null)
            {
                return NotFound();
            }

            return View(curriculum);
        }




        public IActionResult LectureDetails(string? lectureId)
        {
            var lecture = _context.CourseLectures
                .Where(l => l.Id == lectureId)
                .Select(l => new LectureDetailViewModel
                {
                    LectureName = l.Name,
                    VideoUrl = l.VideoUrl,
                    Description = l.Description,
                    Caption = l.Caption,
                    LectureNotes = l.LectureNotes,
                    AttachFile = l.AttachFileUrl
                }).FirstOrDefault();

            return View(lecture);
        }







    }
    
}
