using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace E_TutorApp.Application.Services
{
    public  interface  IEmailService
    {
          Task  SendEmail(string email, string confirmationLink);

    }
}
