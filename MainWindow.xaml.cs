using System;
using System.Collections.Generic;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Dolgozat
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// balra: Gazdag Zsolt
    /// jobbra: Barizs Márton Dániel
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Fuvar> fuvarokLista = File.ReadAllLines("fuvar.csv").Skip(1).Select(x => new Fuvar(x)).ToList();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnHarmadikFeladat_Click(object sender, RoutedEventArgs e)
        {
            txbHarmadikFeladat.Text = $"3. feladat: {fuvarokLista.Count()} fuvar";
        }

        private void btnNegyedikFeladat_Click(object sender, RoutedEventArgs e)
        {
            string bekertTaxiId = txbNegyedikFeladat.Text.ToString();
            MessageBox.Show(fuvarokLista.Exists(x => x.Taxi_id == bekertTaxiId) ? 
                $"{fuvarokLista.Count(x => x.Taxi_id == bekertTaxiId)} fuvar alatt: " +
                $"{(double)fuvarokLista.Where(x => x.Taxi_id == bekertTaxiId).Sum(x => x.Viteldij)+ (double)fuvarokLista.Where(x => x.Taxi_id == bekertTaxiId).Sum(x => x.Borravalo)}$" 
                : $"Ilyen taxi nem létezik");
        }

        private void btnOtodikFeladat_Click(object sender, RoutedEventArgs e)
        {
            fuvarokLista.GroupBy(x => x.Fizetes_modja).ToList().ForEach(x => lbFizetesiModok.Items.Add($"{x.Key}: {x.Count()} fuvar"));
        }

        private void btnHatodikFeladat_Click(object sender, RoutedEventArgs e)
        {
            tbOsszKilometer.Text = $"6. feladat: {((double)fuvarokLista.Sum(x => x.Tavolsag) * 1.6):f2}km";
        }

        private void btnHetedikFeladat_Click(object sender, RoutedEventArgs e)
        {
            var leghosszabbFuvar = fuvarokLista.OrderByDescending(x => x.Idotartam).ToList().First();
            lbLeghosszabbFuvar.Items.Add($"Fuvar hossza: {leghosszabbFuvar.Idotartam} másodperc" +
                $"\nTaxi azonosítója: {leghosszabbFuvar.Taxi_id}" +
                $"\nMegtett távolság: {(leghosszabbFuvar.Tavolsag*1.6):f2} km" +
                $"\nViteldíj: {leghosszabbFuvar.Viteldij}$");
        }

        private void btnNyolcadikFeladat_Click(object sender, RoutedEventArgs e)
        {
            tbNyolcadikFeladat.Text = $"8. feladat: hibak.txt";
            using (StreamWriter stream = File.CreateText("hibak.txt"))
            {
                stream.WriteLine("taxi_id;indulas;idotartam;tavolsag;viteldij;borravalo;fizetes_modja");
            }
                File.AppendAllLines("hibak.txt", fuvarokLista.Where(x => x.Idotartam > 0 && x.Viteldij > 0 && x.Tavolsag == 0).OrderBy(x => x.Indulas).ToList()
                    .Select(x => $"{x.Taxi_id};{x.Indulas};{x.Idotartam};{x.Tavolsag};{x.Viteldij};{x.Borravalo};{x.Fizetes_modja}"));
        }
    }
}
