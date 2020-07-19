using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace coreGalery.Controllers
{
    public class GaleryController : Controller
    {
        public IActionResult Picture(int id)
        {
            return View(id);
        }
    }
}
