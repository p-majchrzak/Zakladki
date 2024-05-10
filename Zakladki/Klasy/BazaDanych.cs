using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Zakladki.Klasy
{
    public class BazaDanych
    {
        private readonly SQLiteConnection bazaDanych;
        public BazaDanych(string sciezka)
        {
            bazaDanych = new SQLiteConnection(sciezka);
            bazaDanych.CreateTable<Ksiazka>();
            bazaDanych.CreateTable<Zakladka>();
        }
        public int Zapisz<T>(T objekt)
        {
            return bazaDanych.Insert(objekt);
        }
        public int Usun<T>(T objekt)
        {
            return bazaDanych.Delete(objekt);
        }
        public int Edytuj<T>(T objekt)
        {
            return bazaDanych.Update(objekt);
        }
        public List<T> Wypisz<T>() where T : new()
        {
            return bazaDanych.Table<T>().ToList();
        }
    }
}
