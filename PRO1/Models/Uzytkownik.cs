using System;
using System.Collections.Generic;

namespace PRO1.Models
{
    public partial class Uzytkownik
    {
        public Uzytkownik()
        {
            Administrator = new HashSet<Administrator>();
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdUzytkownik { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Haslo { get; set; }
        public string Adres { get; set; }
        public int? NumerTelefonu { get; set; }
        public DateTime DataUrodzenia { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public ICollection<Administrator> Administrator { get; set; }
        public ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
