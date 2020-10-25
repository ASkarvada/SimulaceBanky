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
    /// Interakční logika pro DetailUctu.xaml
    /// </summary>
    public partial class DetailUctu : Window
    {
        public DateTime Now { get; set; }
        public double Penize { get; set; }
        public MainWindow Mw { get; set; }
        public DepozitniUcet Dp { get; set; }
        public KreditniUcet Ku { get; set; }
        public StudentskyUcet Su { get; set; }
        public object StaryTag { get; set; }
       
        public DetailUctu(object tag, MainWindow mw, DateTime now, double penize)
        {
            InitializeComponent();
            tbl_historie.IsReadOnly = true;

            Mw = mw;
            Now = now;
            Penize = penize;
            StaryTag = tag;

            if(tag is DepozitniUcet && !(tag is StudentskyUcet))
            {
                Dp = (DepozitniUcet)tag;
                tbl_castka.Text = Dp.AktualniCastka.ToString();
                tbl_jmeno.Text = Dp.Jmeno;
                tbl_popis.Text = Dp.Podrobnosti(Now);
                tbl_historie.Text = Dp.VypisHistorie();
                tbl_moznostCastka.Text = "";
                tbl_moznostText.Text = "";
                tbl_moznostText2.Text = "";
                b_zrusit.Visibility = Visibility.Visible;
            }
            else if(tag is KreditniUcet)
            {
                Ku = (KreditniUcet)tag;
                tbl_castka.Text = Ku.AktualniCastka.ToString();
                tbl_jmeno.Text = Ku.Jmeno;
                tbl_popis.Text = Ku.Podrobnosti(Now);
                tbl_historie.Text = Ku.VypisHistorie();
                tbl_moznostCastka.Text = Math.Abs(Ku.PocatecniUver).ToString();
                tbl_moznostText.Text = "Možnost výběru:";
                tbl_moznostText2.Text = "Kč";
                if(Ku.AktualniCastka < 0) b_zrusit.Visibility = Visibility.Hidden;
                else b_zrusit.Visibility = Visibility.Visible;
            }
            else if (tag is StudentskyUcet)
            {
                Su = (StudentskyUcet)tag;
                tbl_castka.Text = Su.AktualniCastka.ToString();
                tbl_jmeno.Text = Su.Jmeno;
                tbl_popis.Text = Su.Podrobnosti(Now);
                tbl_historie.Text = Su.VypisHistorie();
                tbl_moznostCastka.Text = "";
                tbl_moznostText.Text = "";
                tbl_moznostText2.Text = "";
                b_zrusit.Visibility = Visibility.Visible;
            }
            
            
        }

        public void Opening(string t)
        {
            if(t == "D")
            {
                Dp = (DepozitniUcet)StaryTag;
                tbl_castka.Text = Dp.AktualniCastka.ToString();
                tbl_jmeno.Text = Dp.Jmeno;
                tbl_popis.Text = Dp.Podrobnosti(Now);
                tbl_historie.Text = Dp.VypisHistorie();
                tbl_moznostCastka.Text = "";
                tbl_moznostText.Text = "";
                tbl_moznostText2.Text = "";
                b_zrusit.Visibility = Visibility.Visible;
            }
            else if(t == "K")
            {
                Ku = (KreditniUcet)StaryTag;
                tbl_castka.Text = Ku.AktualniCastka.ToString();
                tbl_jmeno.Text = Ku.Jmeno;
                tbl_popis.Text = Ku.Podrobnosti(Now);
                tbl_historie.Text = Ku.VypisHistorie();
                tbl_moznostCastka.Text = Math.Abs(Ku.PocatecniUver + Ku.AktualniCastka).ToString();
                tbl_moznostText.Text = "Možnost výběru:";
                tbl_moznostText2.Text = "Kč";
                if (Ku.AktualniCastka < 0) b_zrusit.Visibility = Visibility.Hidden;
                else b_zrusit.Visibility = Visibility.Visible;
            }
            else if (t == "S")
            {
                Su = (StudentskyUcet)StaryTag;
                tbl_castka.Text = Su.AktualniCastka.ToString();
                tbl_jmeno.Text = Su.Jmeno;
                tbl_popis.Text = Su.Podrobnosti(Now);
                tbl_historie.Text = Su.VypisHistorie();
                tbl_moznostCastka.Text = "";
                tbl_moznostText.Text = "";
                tbl_moznostText2.Text = "";
                b_zrusit.Visibility = Visibility.Visible;
            }

            
        }

        private void b_vklad_Click(object sender, RoutedEventArgs e)
        {
            VkladVyber novy = new VkladVyber(this, true);
            novy.Show();
        }

        private void b_vyber_Click(object sender, RoutedEventArgs e)
        {
            VkladVyber novy = new VkladVyber(this, false);
            novy.Show();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainWindow open = Mw;
            open.Show();
            open.Penize = Penize;
            open.AktualizaceIkonyUctu(Ku, Dp, Su, StaryTag);
        }

        private void b_zrusit_Click(object sender, RoutedEventArgs e)
        {
            if (StaryTag is DepozitniUcet && !(StaryTag is StudentskyUcet))
            {
                Dp = (DepozitniUcet)StaryTag;
                Dp.PraceSUctem(false, Dp.AktualniCastka, "Zrušení účtu", Now);
                Penize += Dp.AktualniCastka;
                MessageBox.Show($"Zrušení účtu proběhlo úspěšně, vracíme Vám {Dp.AktualniCastka}Kč");
            }
            else if (StaryTag is KreditniUcet)
            {
                Ku = (KreditniUcet)StaryTag;
                Ku.PraceSUctem(false, Ku.AktualniCastka, "Zrušení účtu", Now);
                Penize += Ku.AktualniCastka;
                MessageBox.Show($"Zrušení účtu proběhlo úspěšně, vracíme Vám {Ku.AktualniCastka}Kč");
            }
            else if (StaryTag is StudentskyUcet)
            {
                Su = (StudentskyUcet)StaryTag;
                Su.PraceSUctem(false, Su.AktualniCastka, "Zrušení účtu", Now);
                Penize += Su.AktualniCastka;
                MessageBox.Show($"Zrušení účtu proběhlo úspěšně, vracíme Vám {Su.AktualniCastka}Kč");
            }
            MainWindow open = Mw;
            open.Show();
            open.Penize = Penize;
            open.SmazatUcet(StaryTag);
            this.Close();
        }
    }
}
