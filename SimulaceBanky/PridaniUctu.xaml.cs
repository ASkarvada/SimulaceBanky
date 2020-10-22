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

namespace SimulaceBanky
{
    /// <summary>
    /// Interakční logika pro PridaniUctu.xaml
    /// </summary>
    public partial class PridaniUctu : Window
    {
        MainWindow mw { get; set; }
        public KreditniUcet Ku { get; set; }
        public DepozitniUcet Du { get; set; }
        public bool Kreditni { get; set; }
        public bool Closed { get; set; }
        DateTime Datum { get; set; }
        Double Penize { get; set; }

        public PridaniUctu(double penize, DateTime datum)
        {
            InitializeComponent();
            lb_typ.Items.Add("Kreditní");
            lb_typ.Items.Add("Spořící");
            Datum = datum;
            Penize = penize;
            Closed = false;
        }

        private void b_vklad_Click(object sender, RoutedEventArgs e)
        {
            DateTime od = Datum;
            DateTime ddo = dp_do.SelectedDate.Value; 

            if(od > ddo)
            {
                MessageBox.Show("Zadejte správně dobu splatnosti!");
            }

            int span = (ddo.Month - od.Month) + 12 * (ddo.Year - od.Year);

            if (lb_typ.SelectedItem.ToString() == "Kreditní")
            {
                Ku = new KreditniUcet(tbl_jmeno.Text, Convert.ToDouble(tbl_castka.Text), Convert.ToDouble(tbl_uroceni.Text)/100,new List<string>(), od, span);
                Kreditni = true;
                MessageBox.Show("Úspěšné založení účtu!", "Úvěrový účet");
                this.Close();
            }
            else if(lb_typ.SelectedItem.ToString() == "Spořící")
            {
                if(Penize < Convert.ToDouble(tbl_castka.Text))
                {
                    MessageBox.Show("Nemáte dostatek prostředků.", "Chyba vkladu");
                    this.Close();
                }
                else
                {
                    Du = new DepozitniUcet(tbl_jmeno.Text, Convert.ToDouble(tbl_castka.Text), Convert.ToDouble(tbl_uroceni.Text) / 100, new List<string>(), od, span);
                    Kreditni = false;
                    MessageBox.Show("Úspěšné založení účtu!", "Spořící účet");
                    this.Close();
                }
                
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Closed = true;
            
        }
    }
}
