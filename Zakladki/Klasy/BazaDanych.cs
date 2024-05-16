using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Zakladki.Klasy
{
    public class BazaDanych
    {
        private static string sciezkaKsiazki = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "bazaKsiazki.txt");
        private static string sciezkaZakladki = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "bazaZakladki.txt");
        private static int ostatnieIdKsiazki = 0;
        private static int ostatnieIdZakladki = 0;

        public static void ZapiszKsiazke(List<Ksiazka> lista)
        {
            using (StreamWriter writer = new StreamWriter(sciezkaKsiazki))
            {
                foreach (Ksiazka ksiazka in lista)
                {
                    if (ksiazka.ID == 0)
                    {
                        ostatnieIdKsiazki++;
                        ksiazka.ID = ostatnieIdKsiazki;
                    }
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
                            if (id > ostatnieIdKsiazki)
                            {
                                ostatnieIdKsiazki = id;
                            }
                        }
                    }
                }
            }
            return lista;
        }

        public static void UsunKsiazke(Ksiazka ksiazka)
        {
            List<Ksiazka> lista = OdczytajKsiazki();
            lista.RemoveAll(k => k.ID == ksiazka.ID);
            ZapiszKsiazke(lista);
        }

        public static void ZapiszZakladke(List<Zakladka> lista)
        {
            using (StreamWriter writer = new StreamWriter(sciezkaZakladki))
            {
                foreach (Zakladka zakladka in lista)
                {
                    if (zakladka.ID == 0)
                    {
                        ostatnieIdZakladki++;
                        zakladka.ID = ostatnieIdZakladki;
                    }
                    writer.WriteLine($"{zakladka.ID},{zakladka.Strona},{zakladka.Opis},{zakladka.ID_Ksiazki}");
                }
            }
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
                            if (id > ostatnieIdZakladki)
                            {
                                ostatnieIdZakladki = id;
                            }
                        }
                    }
                }
            }
            return lista;
        }
    }
}
