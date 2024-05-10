using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zakladki.Klasy
{
    public class Ksiazka
    {
        public int ID { get; set; }
        public string Tytul { get; set; } = default!;
        public string Opis { get; set; } = default!;
        public string Autor { get; set; } = default!;
        public DateTime DataWydania { get; set; }
        public Ksiazka() { }
        public Ksiazka(int iD, string tytul, string opis, string autor, DateTime dataWydania)
        {
            ID = iD;
            Tytul = tytul;
            Opis = opis;
            Autor = autor;
            DataWydania = dataWydania;
        }
        public Ksiazka(string tytul, string opis, string autor, DateTime dataWydania)
        {
            Tytul = tytul;
            Opis = opis;
            Autor = autor;
            DataWydania = dataWydania;
        }
    }
}
