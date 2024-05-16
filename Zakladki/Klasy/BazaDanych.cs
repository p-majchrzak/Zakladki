using System;
using System.Collections.Generic;
using System.IO;

namespace Zakladki.Klasy
{
    public class BazaDanych
    {
        private static string sciezkaKsiazki = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "bazaKsiazki.txt");
        private static string sciezkaZakladki = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "bazaZakladki.txt");

        public static void ZapiszKsiazke(List<Ksiazka> lista)
        {
            using (StreamWriter writer = new StreamWriter(sciezkaKsiazki))
            {
                foreach (Ksiazka ksiazka in lista)
                {
                    writer.WriteLine($"{ksiazka.ID},{ksiazka.Tytul},{ksiazka.Opis},{ksiazka.Autor},{ksiazka.DataWydania}");
                }
            }
        }

        public static List<Ksiazka> OdczytajKsiazki()
        {
            List<Ksiazka> lista = new List<Ksiazka>();
            if (File.Exists(sciezkaKsiazki))
            {
                using (StreamReader reader = new StreamReader(sciezkaKsiazki))
                {
                    string linia;
                    while ((linia = reader.ReadLine()) != null)
                    {
                        string[] dane = linia.Split(',');
                        int id;
                        if (int.TryParse(dane[0], out id))
                        {
                            DateTime? dataWydania = null;
                            if (!string.IsNullOrEmpty(dane[4]))
                            {
                                dataWydania = DateTime.Parse(dane[4]);
                            }
                            Ksiazka ksiazka = new Ksiazka(id, dane[1], dane[2], dane[3], dataWydania);
                            lista.Add(ksiazka);
                        }
                    }
                }
            }
            return lista;
        }

        public static void UsunKsiazke(Ksiazka ksiazka, List<Ksiazka> lista)
        {
            lista.Remove(ksiazka);
            ZapiszKsiazke(lista);
        }

        public static void ZapiszZakladke(List<Zakladka> lista)
        {
            using (StreamWriter writer = new StreamWriter(sciezkaZakladki))
            {
                foreach (Zakladka zakladka in lista)
                {
                    writer.WriteLine($"{zakladka.ID},{zakladka.Strona},{zakladka.Opis},{zakladka.ID_Ksiazki}");
                }
            }
        }

        public static void UsunZakladke(Zakladka zakladka, List<Zakladka> lista)
        {
            lista.Remove(zakladka);
            ZapiszZakladke(lista);
        }

        public static List<Zakladka> OdczytajZakladke()
        {
            List<Zakladka> lista = new List<Zakladka>();
            if (File.Exists(sciezkaZakladki))
            {
                using (StreamReader reader = new StreamReader(sciezkaZakladki))
                {
                    string linia;
                    while ((linia = reader.ReadLine()) != null)
                    {
                        string[] dane = linia.Split(',');
                        int id, strona, idKsiazki;
                        if (int.TryParse(dane[0], out id) && int.TryParse(dane[1], out strona) && int.TryParse(dane[3], out idKsiazki))
                        {
                            Zakladka zakladka = new Zakladka(id, strona, dane[2], idKsiazki);
                            lista.Add(zakladka);
                        }
                    }
                }
            }
            return lista;
        }
    }
}
