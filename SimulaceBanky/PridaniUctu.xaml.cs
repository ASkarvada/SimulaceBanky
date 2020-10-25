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
        MainWindow Mw { get; set; }
        public KreditniUcet Ku { get; set; }
        public DepozitniUcet Du { get; set; }
        public StudentskyUcet Su { get; set; }
        public string Typ { get; set; }
        DateTime Datum { get; set; }

        public PridaniUctu(DateTime datum, MainWindow mw)
        {
            InitializeComponent();
            lb_typ.Items.Add("Úvěrový");
            lb_typ.Items.Add("Spořící");
            lb_typ.Items.Add("Studentský spořící");
            Datum = datum;
            tbl_od.Text = $"{Datum.Day}.{Datum.Month}.{Datum.Year}";
            Mw = mw;
        }

        private void b_vklad_Click(object sender, RoutedEventArgs e)
        {
            if (lb_typ.SelectedItem.ToString() == "Úvěrový")
            {
                DateTime ddo = new DateTime();
                try { ddo = dp_do.SelectedDate.Value; }
                catch { MessageBox.Show("Zadejte dobu splatnosti!", "Prázdné pole"); return; }

                if (Datum > ddo)
                {
                    MessageBox.Show("Zadejte správně dobu splatnosti!");
                    return;
                }

                int span = (ddo.Month - Datum.Month) + 12 * (ddo.Year - Datum.Year);

                Ku = new KreditniUcet(tbl_jmeno.Text, Convert.ToDouble(tbl_castka.Text), Convert.ToDouble(tbl_uroceni.Text)/100,new List<string>(), Datum, span, ddo);
                Typ = "K";
                MessageBox.Show("Úspěšné založení účtu!", "Úvěrový účet");
                Zavirani(false);
            }
            else if(lb_typ.SelectedItem.ToString() == "Spořící")
            {
                Du = new DepozitniUcet(tbl_jmeno.Text, 0, Convert.ToDouble(tbl_uroceni.Text) / 100, new List<string>(), Datum);
                Typ = "D";
                MessageBox.Show("Úspěšné založení účtu!", "Spořící účet");
                Zavirani(false);
            }
            else if (lb_typ.SelectedItem.ToString() == "Studentský spořící")
            {
                Su = new StudentskyUcet(tbl_jmeno.Text, 0, Convert.ToDouble(tbl_uroceni.Text) / 100, new List<string>(), Datum, Convert.ToDouble(tbl_omezenost.Text));
                Typ = "S";
                MessageBox.Show("Úspěšné založení účtu!", "Studentský účet");
                Zavirani(false);
            }
        }

        private void Zavirani(bool problem)
        {
            MainWindow open = Mw;
            open.Show();
            if (!problem) open.TvorbaIkonyUctu(this);
            else open.Timmy.Start();
            this.Close();
        }

        private void lb_typ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(lb_typ.SelectedItem.ToString() == "Úvěrový")
            {
                tbl_omezenost.IsReadOnly = true;
                tbl_omezenost.Text = "Pouze pro studentský účet";
                tbl_omezenost.Foreground = Brushes.Gray;
                tbl_castka.IsReadOnly = false;
                tbl_castka.Text = "";
                tbl_castka.Foreground = Brushes.Black;
                dp_do.IsEnabled = true;
            }
            else if (lb_typ.SelectedItem.ToString() == "Spořící")
            {
                tbl_omezenost.IsReadOnly = true;
                tbl_omezenost.Text = "Pouze pro studentský účet";
                tbl_omezenost.Foreground = Brushes.Gray;
                tbl_castka.IsReadOnly = true;
                tbl_castka.Text = "Pouze pro kreditní účet";
                tbl_castka.Foreground = Brushes.Gray;
                dp_do.IsEnabled = false;
            }
            else if (lb_typ.SelectedItem.ToString() == "Studentský spořící")
            {
                tbl_omezenost.IsReadOnly = false;
                tbl_omezenost.Text = "";
                tbl_omezenost.Foreground = Brushes.Black;
                tbl_castka.IsReadOnly = true;
                tbl_castka.Text = "Pouze pro kreditní účet";
                tbl_castka.Foreground = Brushes.Gray;
                dp_do.IsEnabled = false;
            }
        }

        private void b_zrusit_Click(object sender, RoutedEventArgs e)
        {
            Zavirani(true);
        }
    }
}
