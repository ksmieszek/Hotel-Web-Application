using Firma.Data.Data.CMS;
using Firma.Data.Data.Sklep;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Firma.Data.Data
{
    public class HotelContext: DbContext
    {
        public HotelContext(DbContextOptions<HotelContext> options)
            : base(options)
        {
        }

        public DbSet<Rodzaj> Rodzaj { get; set; }

        public DbSet<Towar> Towar { get; set; }

        public DbSet<Pokoje> Pokoje { get; set; }

        public DbSet<Posilki> Posilki { get; set; }

        public DbSet<Pakiety> Pakiety { get; set; }

        public DbSet<ElementKoszyka> ElementKoszyka { get; set; }

    }
}
