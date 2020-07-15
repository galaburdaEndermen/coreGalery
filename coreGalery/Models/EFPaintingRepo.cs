using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
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

        public void EnsureSaved()
        {
            Parallel.ForEach(context.Paintings, (painting) =>
            {
                if (!File.Exists(appEnvironment.WebRootPath + "\\Paintings\\" + painting.FileName))
                {
                    using (System.IO.FileStream fs = new System.IO.FileStream(appEnvironment.WebRootPath + "\\Paintings\\" + painting.FileName, System.IO.FileMode.OpenOrCreate))
                    {
                        fs.Write(painting.ImageData, 0, painting.ImageData.Length);
                    }
                }
            });    
        }

       
    }
}
