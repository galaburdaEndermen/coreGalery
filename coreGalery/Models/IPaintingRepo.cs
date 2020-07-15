using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreGalery.Models
{
    public interface IPaintingRepo
    {
        IQueryable<PaintingModel> Paintings { get; }

        void EnsureSaved();
    }
}
