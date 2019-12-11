using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pizzeria_v2.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            Promocja = new HashSet<Promocja>();
            ZamowieniePizza = new HashSet<ZamowieniePizza>();
        }

        public int IdPizza { get; set; }
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        public string Nazwa { get; set; }
        public int IdSkladnik { get; set; }
        public int Cena { get; set; }
        public int IdRozmiar { get; set; }

        public virtual Rozmiar IdRozmiarNavigation { get; set; }
        public virtual Skladnik IdSkladnikNavigation { get; set; }
        public virtual ICollection<Promocja> Promocja { get; set; }
        public virtual ICollection<ZamowieniePizza> ZamowieniePizza { get; set; }
    }
}
