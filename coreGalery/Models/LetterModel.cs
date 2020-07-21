using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coreGalery.Models
{
    public class LetterModel
    {
        [Required(ErrorMessage = "Вкажіть ім\'я")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Вкажіть тему листа")]
        public string Subject { get; set; }
        [Required(ErrorMessage = "Вкажіть свій e-mail")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Напишіть текст листа")]
        public string Text { get; set; }
    }
}
