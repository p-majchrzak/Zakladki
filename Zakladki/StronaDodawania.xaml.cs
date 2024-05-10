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
    /// Logika interakcji dla klasy StronaDodawania.xaml
    /// </summary>
    public partial class StronaDodawania : Window
    {
        public StronaDodawania()
        {
            InitializeComponent();
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Ksiazka ksiazka = new Ksiazka(Tytul.Text, Opis.Text, Autor.Text, Data.SelectedDate);
            App.Baza.Zapisz(ksiazka);
            Close();
        }
    }
}
