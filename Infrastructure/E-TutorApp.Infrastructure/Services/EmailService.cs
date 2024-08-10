using E_TutorApp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public async Task  SendEmail(string email, string confirmationLink)
        {
            var smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential("mahamguziyev@gmail.com", "pinr ggnw dogk zmle");
            smtp.EnableSsl = true;

            MailMessage mail = new MailMessage();
            mail.Subject = "Confirm your email";
            mail.Body = $"<a href='{confirmationLink}'>Click to Btn And Comfirm Email</a>";
            mail.IsBodyHtml = true;
            mail.From = new MailAddress("mahamguziyev@gmail.com");
            mail.To.Add(email);

            smtp.Send(mail);
            
        }
    }
}
