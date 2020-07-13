using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreGalery.Models
{
    public class EFPaintingRepo : IPaintingRepo
    {
        private GaleryDbContext context;
        public EFPaintingRepo(GaleryDbContext context)
        {
            this.context = context;
        }

        public IQueryable<PaintingModel> Paintings => context.Paintings;
    }
}
