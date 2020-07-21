using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using coreGalery.Models;
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
            //обработать пісьмо
            return RedirectToAction(nameof(Success));
        }

        [HttpGet]
        public ViewResult Success()
        {
            return View();
        }
    }
}
