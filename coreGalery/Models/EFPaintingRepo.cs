using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace coreGalery.Models
{
    public class EFPaintingRepo : IPaintingRepo
    {
        private GaleryDbContext context;
        IWebHostEnvironment appEnvironment;
        public EFPaintingRepo(GaleryDbContext context, IWebHostEnvironment appEnvironment)
        {
            this.context = context;
            this.appEnvironment = appEnvironment;
        }

        public IQueryable<PaintingModel> Paintings { get { EnsureSaved(); return context.Paintings; } }

        //перевести на многопоток
        public void EnsureSaved()
        {
            foreach (PaintingModel painting in context.Paintings)
            {
                try
                {
                    if (!File.Exists(appEnvironment.WebRootPath + "\\Paintings\\" + painting.FileName))
                    {
                        using (System.IO.FileStream fs = new System.IO.FileStream(appEnvironment.WebRootPath + "\\Paintings\\" + painting.FileName, System.IO.FileMode.OpenOrCreate))
                        {
                            fs.Write(painting.ImageData, 0, painting.ImageData.Length);
                        }
                    }
                }
                catch (Exception e)
                {
                    string sas = e.Message;
                }
                               
            }
        }

        //перевести на многопоток
        //можна удалить
        public void EnsureSaved(int id)
        {
            PaintingModel painting = context.Paintings.Find(id);
            try
            {
                if (!File.Exists(appEnvironment.WebRootPath + "\\Paintings\\" + painting.FileName))
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(appEnvironment.WebRootPath + "\\Paintings\\" + painting.FileName, System.IO.FileMode.OpenOrCreate))
                    {
                        fs.Write(painting.ImageData, 0, painting.ImageData.Length);
                    }
                }
            }
            catch (Exception e)
            {
                string sas = e.Message;
            }
        }
    }
}
