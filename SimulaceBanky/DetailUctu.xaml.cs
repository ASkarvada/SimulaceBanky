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

            if(tag is DepozitniUcet)
            {
                Dp = (DepozitniUcet)tag;
                tbl_castka.Text = Dp.AktualniCastka.ToString();
                tbl_jmeno.Text = Dp.Jmeno;
                tbl_popis.Text = Dp.Podrobnosti(Now);
                tbl_historie.Text = Dp.VypisHistorie();
            }
            else if(tag is KreditniUcet)
            {
                Ku = (KreditniUcet)tag;
                tbl_castka.Text = Ku.AktualniCastka.ToString();
                tbl_jmeno.Text = Ku.Jmeno;
                tbl_popis.Text = Ku.Podrobnosti(Now);
                tbl_historie.Text = Ku.VypisHistorie();
            }
            else if (tag is StudentskyUcet)
            {
                Su = (StudentskyUcet)tag;
                tbl_castka.Text = Su.AktualniCastka.ToString();
                tbl_jmeno.Text = Su.Jmeno;
                tbl_popis.Text = Su.Podrobnosti(Now);
                tbl_historie.Text = Su.VypisHistorie();
            }
            
            
        }

        public void Opening(string t)
        {
            if(t == "D")
            {
                tbl_castka.Text = Dp.AktualniCastka.ToString();
                tbl_jmeno.Text = Dp.Jmeno;
                tbl_popis.Text = Dp.Podrobnosti(Now);
                tbl_historie.Text = Dp.VypisHistorie();
            }
            else if(t == "K")
            {
                Ku = (KreditniUcet)StaryTag;
                tbl_castka.Text = Ku.AktualniCastka.ToString();
                tbl_jmeno.Text = Ku.Jmeno;
                tbl_popis.Text = Ku.Podrobnosti(Now);
                tbl_historie.Text = Ku.VypisHistorie();
            }
            else if (t == "S")
            {
                Su = (StudentskyUcet)StaryTag;
                tbl_castka.Text = Su.AktualniCastka.ToString();
                tbl_jmeno.Text = Su.Jmeno;
                tbl_popis.Text = Su.Podrobnosti(Now);
                tbl_historie.Text = Su.VypisHistorie();
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
    }
}
