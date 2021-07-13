using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Firma.Data.Data.Sklep
{
    public class Towar
    {
        [Key]
        public int IdTowaru { get; set; }

        [Required(ErrorMessage = "Nazwa towaru jest wymagana")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string Nazwa { get; set; }

        [Required(ErrorMessage = "Cena jest wymagana")]
        [Column(TypeName = "money")]
        public decimal Cena { get; set; }

        [Required(ErrorMessage = "Zdjęcie jest wymagane")]
        [Display(Name = "URL zdjęcia")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string UrlZdjecia { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        public string Opis { get; set; }

        [Display(Name = "Krótki opis")]
        [Column(TypeName = "nvarchar(MAX)")]
        public string KrotkiOpis { get; set; }

        
        public int IdRodzaju { get; set; }
        public virtual Rodzaj Rodzaj { get; set; }
    }
}
