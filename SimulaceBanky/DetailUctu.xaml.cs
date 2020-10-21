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
        
       
        public DetailUctu(object tag)
        {
            InitializeComponent();
            if(tag is DepozitniUcet)
            {
                DepozitniUcet dp = (DepozitniUcet)tag;
                tbl_castka.Text = dp.AktualniCastka.ToString();
                tbl_jmeno.Text = dp.Jmeno;
                tbl_popis.Text = dp.ToString();
                tbl_historie.Text = dp.VypisHistorie();
            }
            else if(tag is KreditniUcet)
            {
                KreditniUcet dp = (KreditniUcet)tag;
                tbl_castka.Text = dp.AktualniCastka.ToString();
                tbl_jmeno.Text = dp.Jmeno;
                tbl_popis.Text = dp.ToString();
                tbl_historie.Text = dp.VypisHistorie();
            }
            
            
        }

        private void b_vklad_Click(object sender, RoutedEventArgs e)
        {

        }

        private void b_vyber_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
