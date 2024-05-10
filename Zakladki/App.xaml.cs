using System.Configuration;
using System.Data;
using System.IO;
using System.Windows;
using Zakladki.Klasy;

namespace Zakladki
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static BazaDanych? baza;
        public static BazaDanych Baza
        {
            get
            {
                if (baza == null)
                {
                    baza = new BazaDanych(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "bazaZakladki.db3"));
                }
                return baza;
            }
        }
    }

}
