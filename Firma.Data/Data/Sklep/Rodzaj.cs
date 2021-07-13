using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Firma.Data.Data.Sklep
{
    public class Rodzaj
    {
        [Key]
        public int IdRodzaju { get; set; }

        [Required(ErrorMessage = "Nazwa rodzaju jest wymagana")]
        [MaxLength(15, ErrorMessage = "Nazwa rodzaju powinna mieć max 15 znaków")]
        public string Nazwa { get; set; }

        public string Opis { get; set; }

        public virtual ICollection<Towar> Towar { get; set; }
    }
}
