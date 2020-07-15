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
        private IPaintingRepo repo;
        public HomeController(IPaintingRepo repo)
        {
            this.repo = repo;
        }

        public ViewResult Index()
        {
            return View(repo.Paintings.ToList());
        }
    }
}
