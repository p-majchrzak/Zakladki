using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zakladki.Klasy
{
    public class Zakladka
    {
        [PrimaryKey, AutoIncrement] public int ID { get; set; }
        public int Strona { get; set; }
        public string Opis { get; set; }
        public int ID_Ksiazki { get; set; } 
        public Zakladka() { }
        public Zakladka(int iD, int strona, string opis, int iD_Ksiazki)
        {
            ID = iD;
            Strona = strona;
            Opis = opis;
            ID_Ksiazki = iD_Ksiazki;
        }
        public Zakladka(int strona, string opis, int iD_Ksiazki)
        {
            Strona = strona;
            Opis = opis;
            ID_Ksiazki = iD_Ksiazki;
        }
    }
}
