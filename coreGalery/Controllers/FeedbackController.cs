using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreGalery.Models;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;

namespace coreGalery.Controllers
{
    public class FeedbackController : Controller
    {
        [HttpGet]
        public ViewResult Form()
        {
            return View(new LetterModel());
        }

        [HttpPost]
        public IActionResult Form(LetterModel letter)
        {
            Task.Run(() =>
            {
                MailAddress from = new MailAddress("galaburda0test@gmail.com", "Mail from gallery");
                MailAddress to = new MailAddress("tipa1488amerikos@gmail.com");
                MailMessage m = new MailMessage(from, to);
                m.Subject = letter.Subject;
                m.Body = letter.Text + "\n\n\n" + letter.Email + "\t" + letter.Name;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("galaburda0test@gmail.com", "test007A");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.EnableSsl = true;
                smtp.Send(m);
            });


            return RedirectToAction(nameof(Success));
        }

        [HttpGet]
        public ViewResult Success()
        {
            return View();
        }
    }
}
