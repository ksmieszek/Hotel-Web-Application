using Firma.Data.Data;
using Firma.Data.Data.Sklep;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firma.PortalWWW.Models.BusinessLogic
{
    public class KoszykB
    {
        private readonly HotelContext _context; 
        private string IdSesjiKoszyka; 

        public KoszykB(HotelContext context, HttpContext httpContext)
        {
            _context = context;
            this.IdSesjiKoszyka = GetIdSesjiKoszyka(httpContext);
        }

        private string GetIdSesjiKoszyka(HttpContext httpContext)
        {
            //jezeli id sesji koszyka jest nullem 
            if (httpContext.Session.GetString("IdSesjiKoszyka") == null)
            {
                //jezeli identy uzytkownika nie jest puste i nie posiada bialych znakow
                if (!string.IsNullOrWhiteSpace(httpContext.User.Identity.Name))
                {
                    //wtedy staje sie id sesji koszyka
                    httpContext.Session.SetString("IdSesjiKoszyka", httpContext.User.Identity.Name);
                }
                else
                {
                    //w przeciwnym wypadku generujemy idsesjikoszyka przy pomocy guid
                    Guid tempIdSesjiKoszyka = Guid.NewGuid();
                    httpContext.Session.SetString("IdSesjiKoszyka", tempIdSesjiKoszyka.ToString());
                }
            }
            return httpContext.Session.GetString("IdSesjiKoszyka").ToString();
        }

        public void DodajDoKoszyka(Towar towar)
        {
            var elementKoszyka = _context.ElementKoszyka.Where(e => e.IdTowaru == towar.IdTowaru && e.IdSesjiKoszyka == IdSesjiKoszyka).FirstOrDefault();
            
            if (elementKoszyka == null)
            {
                elementKoszyka = new ElementKoszyka()
                {
                    IdSesjiKoszyka = this.IdSesjiKoszyka,
                    IdTowaru = towar.IdTowaru,
                    Towar = _context.Towar.Find(towar.IdTowaru),
                    Ilosc = 1,
                    DataUtworzenia = DateTime.Now
                };
                _context.ElementKoszyka.Add(elementKoszyka);
            }
            else
            {
                elementKoszyka.Ilosc++;
            }
            _context.SaveChanges();
        }

        public async Task<List<ElementKoszyka>> GetElementKoszyka()
        {
            return await _context.ElementKoszyka.Where(e => e.IdSesjiKoszyka == IdSesjiKoszyka).Include(e => e.Towar).ToListAsync();
        }

        public async Task<decimal> GetRazem()
        {
            var suma = (
                    from element in _context.ElementKoszyka
                    where element.IdSesjiKoszyka == this.IdSesjiKoszyka
                    select (decimal?)element.Ilosc * element.Towar.Cena
                ).SumAsync();

            return await suma ?? decimal.Zero;
        }
    }
}
