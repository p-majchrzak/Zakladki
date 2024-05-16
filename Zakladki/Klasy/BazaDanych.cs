using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Zakladki.Klasy
{
    public class BazaDanych
    {
        private static string sciezkaKsiazki = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ksiazki.json");
        private static string sciezkaZakladki = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "zakladki.json");

        public static void ZapiszKsiazke(List<Ksiazka> lista)
        {
            File.WriteAllText(sciezkaKsiazki, JsonSerializer.Serialize(lista));
        }

        public static List<Ksiazka> OdczytajKsiazki()
        {
            if (File.Exists(sciezkaKsiazki))
            {
                string zawartosc = File.ReadAllText(sciezkaKsiazki);
                if (!string.IsNullOrEmpty(zawartosc))
                {
                    List<Ksiazka> lista = JsonSerializer.Deserialize<List<Ksiazka>>(zawartosc);
                    return lista;
                }
            }
            return new List<Ksiazka>();
        }

        public static void UsunKsiazke(Ksiazka ksiazka, List<Ksiazka> lista)
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
            if (File.Exists(sciezkaZakladki))
            {
                string zawartosc = File.ReadAllText(sciezkaZakladki);
                if (!string.IsNullOrEmpty(zawartosc))
                {
                    List<Zakladka> lista = JsonSerializer.Deserialize<List<Zakladka>>(zawartosc);
                    return lista;
                }
            }
            return new List<Zakladka>();
        }
    }
}
