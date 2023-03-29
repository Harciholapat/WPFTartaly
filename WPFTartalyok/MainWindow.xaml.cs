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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Osztalyaim;
using System.IO;

namespace WPFTartalyok
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            rdoTeglatest.IsChecked = true;
        }

        List<Tartaly> tartalyok = new List<Tartaly> ();

        private void rdoKocka_Checked(object sender, RoutedEventArgs e)
        {
            txtAel.IsEnabled = false;
            txtBel.IsEnabled = false;
            txtCel.IsEnabled = false;
            txtAel.Text = "10";
            txtBel.Text = "10";
            txtCel.Text = "10";
        }

        private void rdoTeglatest_Checked(object sender, RoutedEventArgs e)
        {
            txtAel.IsEnabled = true;
            txtBel.IsEnabled = true;
            txtCel.IsEnabled = true;
            txtAel.Text = "";
            txtBel.Text = "";
            txtCel.Text = "";
        }

        private void btnFelvesz_Click(object sender, RoutedEventArgs e)
        {
            {
                Tartaly ujtartaly = new Tartaly(txtNev.Text, int.Parse(txtAel.Text), int.Parse(txtBel.Text), int.Parse(txtCel.Text));
                lbTartalyok.Items.Add(ujtartaly.Info());
                tartalyok.Add(ujtartaly);
            }
        }

        private void btnRogzit_Click(object sender, RoutedEventArgs e)
        {
            StreamWriter sw = new StreamWriter("./tartaly.csv", true);
            tartalyok.ForEach(aktElem => sw.WriteLine(aktElem.Info() + ";"));
            sw.Close();
        }

        private void btnDuplaz_Click(object sender, RoutedEventArgs e)
        {
            tartalyok[lbTartalyok.SelectedIndex].DuplazMeretet();
            lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
        }

        private void btnLeenged_Click(object sender, RoutedEventArgs e)
        {
            tartalyok[lbTartalyok.SelectedIndex].TeljesLeengedes();
            lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
        }

        private void btntolt_Click(object sender, RoutedEventArgs e)
        {
            tartalyok[lbTartalyok.SelectedIndex].Tolt(double.Parse(txtMennyitTolt.Text));
            lbTartalyok.Items[lbTartalyok.SelectedIndex] = tartalyok[lbTartalyok.SelectedIndex].Info();
        }
    }
}
