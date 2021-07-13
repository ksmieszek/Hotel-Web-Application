using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Firma.Data.Data.CMS
{
    public class Pokoje
    {
        [Key]
        public int IdPokoju { get; set; }

        [Required(ErrorMessage = "Nazwa pokoju jest wymagana")]
        [Display(Name = "Nazwa pokoju")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Podanie powierzchni jest wymagane")]
        [Display(Name = "Powierzchnia")]
        public int Powierzchnia { get; set; }

        [Required(ErrorMessage = "Podanie ilości łóżek jest wymagane")]
        [Display(Name = "Ilość łóżek")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string IloscLozek { get; set; }

        [Required(ErrorMessage = "Podanie ilości osób jest wymagane")]
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


