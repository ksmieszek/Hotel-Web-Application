using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Firma.Data.Data.Sklep
{
    public class ElementKoszyka
    {
        [Key]
        public int IdElementuKoszyka { get; set; }
        public string IdSesjiKoszyka { get; set; }
        public int IdTowaru { get; set; }
        public virtual Towar Towar { get; set; }
        public int Ilosc { get; set; }
        public DateTime DataUtworzenia { get; set; }
    }
}
