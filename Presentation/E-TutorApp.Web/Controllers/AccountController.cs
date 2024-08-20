using E_TutorApp.Domain.Entities.Concretes;
using E_TutorApp.Domain.ViewModels;
using E_TutorApp.Persistence.Db_Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using E_TutorApp.Application.Services;
using E_TutorApp.Domain.ViewModels.AccountVMs;

namespace E_TutorApp.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly TutorDbContext _context;
        private readonly UserManager <User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmailService _emailService;

        public AccountController(TutorDbContext context, UserManager<User> userManager = null, SignInManager<User> signInManager = null, IEmailService emailService = null)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailService = emailService;
        }

        public IActionResult Login(string? ReturnUrl = null)
        {
            ViewBag.ReturnUrl = ReturnUrl;  
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM, string? ReturnUrl = null)
        {
            if(!ModelState.IsValid) return View(loginVM);
            var user = new User();
            if (GetInputType(loginVM.EmailOrUsername) == "email")
            {
                 user = await _userManager.FindByEmailAsync(loginVM.EmailOrUsername);
            }
            else 
            {    user = await _userManager.FindByNameAsync(loginVM.EmailOrUsername); }

            if(user is null) { ModelState.AddModelError("All", "User Not found"); return View(loginVM); }
            if(!user.EmailConfirmed ) { ModelState.AddModelError("All", "Email not confirmed"); return View(loginVM); }


            //var result = await _userManager.CheckPasswordAsync(user, loginVM.Password);
            //if(result == false)
            //{
            //    ModelState.AddModelError("All", "Invalid Password");
            //    return View(loginVM);
            //}

            //await _signInManager.SignInAsync(user, loginVM.RememberMe);
            //if(string.IsNullOrEmpty(ReturnUrl)) return RedirectToAction("Index", "Home");

            //return Redirect(ReturnUrl);

            var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password,loginVM.RememberMe, true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError("All", $"Your Account locked out :  {5 - user.AccessFailedCount}");
            }
            else if(!result.Succeeded) {
                ModelState.AddModelError("All", $"Wrong Password. Your have {5 - user.AccessFailedCount} chance for Locked out");
            }
            else if (result.Succeeded)
            {  
                
                if (!string.IsNullOrEmpty(ReturnUrl)) return Redirect(ReturnUrl);

                var roles = await _userManager.GetRolesAsync(user);
                if (roles.Contains("Student"))
                {
                    return RedirectToAction("StudentDashboard", "Student");
                }
                else if (roles.Contains("Instructor"))
                {
                    return RedirectToAction("InstructorDashboard", "Instructor");
                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            
            return View(loginVM);

        }
        [NonAction]
        public static string GetInputType(string userInput)
        {
            // Email regex pattern
            string emailPattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            if (Regex.IsMatch(userInput, emailPattern))
            {
                return "email";
            }
            else
            {
                return "username";
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);
            if (!registerVM.Conditions) { ModelState.AddModelError("All", "You must agree to the terms and conditions before proceeding."); return View(registerVM); }

            var newUser = new User()
            {
                Bio = "Me",
                ProfilePicture = "Me.jpeg",
                LastName = registerVM.LastName,
                UserName = registerVM.Username,
                Email = registerVM.Email,
            };
            var result = await _userManager.CreateAsync(newUser, registerVM.Password);
            if (result.Succeeded)
            {
                var newtoken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
                var confirmationLink = Url.Action("ConfirmEmail", "Home", new { email = newUser.Email, token = newtoken }, Request.Scheme);
       
                //Email Service
                await _emailService.SendEmail(newUser.Email, confirmationLink);

                await _userManager.AddToRoleAsync(newUser, "Student");

                var studDetail = new DetailStudent () { Student =  newUser, StudentId = newUser.Id };
                await _context.DetailStudents .AddAsync(studDetail);
                await _context.SaveChangesAsync();

                return RedirectToAction("Login", "Account");
            }
            else
            {
                foreach (var item in result.Errors) ModelState.AddModelError("All", item.Description);
                return View(registerVM);
            }
        }

        #region Servissiz Register post
        //[HttpPost ]
        //public async Task <IActionResult> Register(RegisterVM registerVM)
        //{
        //    if (!ModelState .IsValid) return View(registerVM);
        //    if(!registerVM.Agreed) { ModelState.AddModelError("All", "You must agree to the terms and conditions before proceeding."); return View(registerVM); }


        //    var newUser = new User()
        //    {
        //        Bio = "Me", 
        //        ProfilePicture = "Me.jpeg",
        //        LastName = registerVM.LastName,
        //        UserName = registerVM.UserName,
        //        Email = registerVM.Email,
        //    };

        //    var result = await _userManager.CreateAsync(newUser, registerVM.Password);
        //    if (result.Succeeded)
        //    {
        //        var newtoken = await _userManager.GenerateEmailConfirmationTokenAsync(newUser);
        //        var confirmationLink = Url.Action("ConfirmEmail", "Home", new { email = newUser.Email, token = newtoken }, Request.Scheme);
        //        // Email Sent SMTP
        //        var smtp = new SmtpClient("smtp.gmail.com", 587);
        //        smtp.Credentials = new NetworkCredential("mahamguziyev@gmail.com", "pinr ggnw dogk zmle");
        //        smtp.EnableSsl = true;

        //        MailMessage mail = new MailMessage();
        //        mail.Subject = "Confirm your email";
        //        mail.Body = $"<a href='{confirmationLink}'>Click to Btn And Comfirm Email</a>";
        //        mail.IsBodyHtml = true;
        //        mail.From = new MailAddress("mahamguziyev@gmail.com");
        //        mail.To.Add(newUser.Email);

        //        smtp.Send(mail);

        //        await _userManager.AddToRoleAsync(newUser, "Student");
        //        return RedirectToAction("Login", "Account");
        //    }
        //    else
        //    {
        //        foreach (var item in result.Errors) ModelState.AddModelError("All", item.Description);
        //        return View(registerVM);
        //    }
        //}
        #endregion

        public async Task< IActionResult> AccessDenied()
        {
            return View();
        }











    }
}
