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
    /// Logika interakcji dla klasy Podstrona.xaml
    /// </summary>
    public partial class Podstrona : Window
    {
        Ksiazka _Ksiazka { get; set; }
        public Podstrona(Ksiazka ksiazka)
        {
            InitializeComponent();
            _Ksiazka = ksiazka;
            Odswiez_Liste();
        }
        public void Odswiez_Liste()
        {
            ListaZakladek.ItemsSource = App.Baza.Wypisz<Zakladka>().Where(Zakladka => Zakladka.ID_Ksiazki==_Ksiazka.ID).ToList();
        }
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Zakladka zakladka = new Zakladka(int.Parse(Strona.Text), Opis.Text, _Ksiazka.ID);
            App.Baza.Zapisz(zakladka);
            Odswiez_Liste();
        }

        private void ListaZakladek_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Zakladka zakladka = ListaZakladek.SelectedItem as Zakladka;
            MessageBox.Show("Opis: " + zakladka.Opis + " na str." + zakladka.Strona);
        }
    }
}
