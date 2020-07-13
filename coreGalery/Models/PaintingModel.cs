using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreGalery.Models
{
    public class PaintingModel
    {
        public int Id { get; set; }
        public byte[] ImageData { get; set; }
        public string FileName { get; set; }
        public string PictureName { get; set; }
        public string Description { get; set; }
    }
}
