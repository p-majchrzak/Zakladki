using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Zakladki.Klasy
{
    public class BazaDanych
    {
        private static string sciezkaKsiazki = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ksiazki.json");
        private static string sciezkaZakladki = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "zakladki.json");

        public static void ZapiszKsiazke(List<Ksiazka> lista)
        {
            List<Ksiazka> istniejaceKsiazki = OdczytajKsiazki();
            ZapiszDoPliku(lista, istniejaceKsiazki, sciezkaKsiazki);
        }

        public static List<Ksiazka> OdczytajKsiazki()
        {
            return OdczytajZPliku<Ksiazka>(sciezkaKsiazki);
        }

        public static void UsunKsiazke(Ksiazka ksiazka)
        {
            List<Ksiazka> istniejaceKsiazki = OdczytajKsiazki();
            istniejaceKsiazki.RemoveAll(k => k.ID == ksiazka.ID);
            ZapiszDoPliku(istniejaceKsiazki, sciezkaKsiazki);
        }

        public static void ZapiszZakladke(List<Zakladka> lista)
        {
            List<Zakladka> istniejaceZakladki = OdczytajZakladke();
            ZapiszDoPliku(lista, istniejaceZakladki, sciezkaZakladki);
        }

        public static void UsunZakladke(List<Zakladka> lista)
        {
            ZapiszZakladke(lista);
        }

        public static List<Zakladka> OdczytajZakladke()
        {
            return OdczytajZPliku<Zakladka>(sciezkaZakladki);
        }

        private static List<T> OdczytajZPliku<T>(string sciezka)
        {
            if (File.Exists(sciezka))
            {
                string zawartosc = File.ReadAllText(sciezka);
                return JsonSerializer.Deserialize<List<T>>(zawartosc);
            }
            return new List<T>();
        }

        private static void ZapiszDoPliku<T>(List<T> noweObiekty, List<T> istniejaceObiekty, string sciezka)
        {
            int najwyzszeID = istniejaceObiekty.Any() ? ZnajdzNajwyzszeID(istniejaceObiekty) : 0;

            foreach (dynamic obiekt in noweObiekty)
            {
                najwyzszeID++;
                obiekt.ID = najwyzszeID;
            }

            List<T> wszystkieObiekty = istniejaceObiekty.Concat(noweObiekty).ToList();
            File.WriteAllText(sciezka, JsonSerializer.Serialize(wszystkieObiekty));
        }

        private static void ZapiszDoPliku<T>(List<T> lista, string sciezka)
        {
            File.WriteAllText(sciezka, JsonSerializer.Serialize(lista));
        }

        private static int ZnajdzNajwyzszeID<T>(List<T> obiekty)
        {
            return obiekty.Select(obiekt => (int)obiekt.GetType().GetProperty("ID").GetValue(obiekt)).Max();
        }
    }
}
