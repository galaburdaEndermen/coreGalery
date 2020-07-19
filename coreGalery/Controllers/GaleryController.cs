using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using coreGalery.Models;
using Microsoft.AspNetCore.Mvc;

namespace coreGalery.Controllers
{
    public class GaleryController : Controller
    {
        private IPaintingRepo repo;
        public GaleryController(IPaintingRepo repo)
        {
            this.repo = repo;
        }

        public ViewResult Picture(int id)
        {
            if (id == 0)
            {
                throw new Exception("Not found");
            }

            List<int> ids = (from p in repo.Paintings select p.Id).ToList<int>();
            if (!ids.Contains(id))
            {
                throw new Exception("Not found");
            }

            ViewBag.leftId = 0;
            if (id != ids[0])
            {
                ViewBag.leftId = ids[ids.IndexOf(id) - 1];
            }
            else
            {
                ViewBag.leftId = id;
            }

            ViewBag.rightId = 0;
            if (id != ids[ids.Count - 1])
            {
                ViewBag.rightId = ids[ids.IndexOf(id) + 1];
            }
            else
            {
                ViewBag.rightId = id;
            }

            PaintingModel picture = repo.Paintings.First(p => p.Id == id);


            return View(picture);
        }
    }
}
