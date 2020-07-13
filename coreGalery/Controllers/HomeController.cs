using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using coreGalery.Models;

namespace coreGalery.Controllers
{
    public class HomeController : Controller
    {
        private GaleryDbContext context;
        public HomeController(GaleryDbContext context)
        {
            this.context = context;
        }

        public ViewResult Index()
        {
            return View(context.Paintings.ToList());
        }
    }
}
