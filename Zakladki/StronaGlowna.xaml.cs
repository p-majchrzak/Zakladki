using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Zakladki.Klasy;

namespace Zakladki
{
    /// <summary>
    /// Logika interakcji dla klasy StronaGlowna.xaml
    /// </summary>
    public partial class StronaGlowna : Window
    {
        public StronaGlowna()
        {
            InitializeComponent();
            ZaladujDane();
        }

        public void ZaladujDane()
        {
            ListaKsiazek.ItemsSource = BazaDanych.OdczytajKsiazki();
        }
        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            Ksiazka ksiazka = ListaKsiazek.SelectedItem as Ksiazka;
            BazaDanych.UsunKsiazke(ksiazka,BazaDanych.OdczytajKsiazki());
            ZaladujDane();
        }

        private void Zakladki_Click(object sender, RoutedEventArgs e)
        {
            Podstrona podstrona = new Podstrona(ListaKsiazek.SelectedItem as Ksiazka);
            podstrona.ShowDialog();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            StronaDodawania strona = new StronaDodawania();
            strona.ShowDialog();
            ZaladujDane();
        }
    }
}
