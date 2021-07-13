using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Firma.Data.Data.CMS
{
    public class Posilki
    {
        [Key]
        public int IdPosilku { get; set; }

        [Required(ErrorMessage = "Nazwa polska jest wymagana")]
        [Display(Name = "Nazwa posiłku(pl)")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string NazwaPolska { get; set; }

        [Required(ErrorMessage = "Nazwa angielska jest wymagana")]
        [Display(Name = "Nazwa posiłku(ang)")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string NazwaAngielska { get; set; }

        [Required(ErrorMessage = "Zdjęcie jest wymagane")]
        [Display(Name = "URL zdjęcia")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string UrlZdjecia { get; set; }
    }
}
