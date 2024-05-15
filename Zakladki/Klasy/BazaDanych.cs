using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.Text.Json;
using System.IO;

namespace Zakladki.Klasy
{
    public class BazaDanych
    {
        private static string sciezkaKsiazki = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "bazaKsiazkai.json");
        private static string sciezkaZakladki = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "bazaZakladki.json");
        public static void ZapiszKsiazke(List<Ksiazka> lista)
        {
            File.WriteAllText(sciezkaKsiazki, JsonSerializer.Serialize(lista));
        }
        public static List<Ksiazka> OdczytajKsiazki()
        {
            if(File.Exists(sciezkaKsiazki))
            {
                string zawartosc = File.ReadAllText(sciezkaKsiazki);
                List<Ksiazka> lista = JsonSerializer.Deserialize<List<Ksiazka>>(zawartosc);
                return lista;
            }
            else
            {
                File.Create(sciezkaKsiazki);
                List<Ksiazka> lista = new List<Ksiazka>();
                return lista;
            }
            
        }
        public static void UsunKsiazke(Ksiazka ksiazka,  List<Ksiazka> lista)
        {
            lista.Remove(ksiazka);
            ZapiszKsiazke(lista);
        }
        public static void ZapiszZakladke(List<Zakladka> lista)
        {
            File.WriteAllText(sciezkaZakladki, JsonSerializer.Serialize(lista));
        }
        public static void UsunZakladke(Zakladka zakladka, List<Zakladka> lista)
        {
            lista.Remove(zakladka);
            ZapiszZakladke(lista);
        }
        public static List<Zakladka> OdczytajZakladke()
        {
            string zawartosc = File.ReadAllText(sciezkaKsiazki);
            List<Zakladka> lista = JsonSerializer.Deserialize<List<Zakladka>>(zawartosc);
            return lista;
        }
    }
}
