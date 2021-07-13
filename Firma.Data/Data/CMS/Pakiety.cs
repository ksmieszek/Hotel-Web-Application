using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Firma.Data.Data.CMS
{
    public class Pakiety
    {
        [Key]
        public int IdPokoju { get; set; }

        [Required(ErrorMessage = "Nazwa pakietu jest wymagana")]
        [Display(Name = "Nazwa pakietu")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Tytul { get; set; }

        [Required(ErrorMessage = "Podanie informacji o czasie trwania jest wymagane")]
        [Display(Name = "Czas trwania")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Czas { get; set; }

        [Required(ErrorMessage = "Podanie informacji o posiłkach jest wymagane")]
        [Display(Name = "Posiłki")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Posilki { get; set; }

        [Required(ErrorMessage = "Podanie informacji o ilości osób jest wymagane")]
        [Display(Name = "Ilość osób")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string IloscOsob { get; set; }

        [Required(ErrorMessage = "Zdjęcie jest wymagane")]
        [Display(Name = "URL zdjęcia")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string UrlZdjecia { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana")]
        [Column(TypeName = "money")]
        public decimal Cena { get; set; }
    }
}
