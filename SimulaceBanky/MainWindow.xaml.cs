using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
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

namespace SimulaceBanky
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int ID { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            ID = 0;
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock tbl = sender as TextBlock;
            if (tbl.Tag is KreditniUcet)
            {
                DetailUctu novy = new DetailUctu(tbl.Tag);
            }
            else if (tbl.Tag is DepozitniUcet)
            {
                DetailUctu novy = new DetailUctu(tbl.Tag);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PridaniUctu novy = new PridaniUctu(Convert.ToDouble(tbl_penize.Text), Convert.ToDateTime(tbl_datum.Text));
            novy.Show();

            TvorbaIkonyUctu(novy);


        }

        

        public void TvorbaIkonyUctu(PridaniUctu novy)
        {
            ID++;
            int y = 7;
            st.Children.Add(new TextBlock { Name = $"u{ID}", Margin = new Thickness { Top = y }, TextWrapping = TextWrapping.Wrap, Width = 776, Height = 50, FontFamily = new FontFamily("Franklin Gothic Demi"), FontSize = 22, Background = new SolidColorBrush(Color.FromRgb(251, 216, 122)) });

            foreach (UIElement control in st.Children)
            {
                if (control.GetType() == typeof(TextBlock))
                {
                    TextBlock tb = control as TextBlock;
                    if (tb.Name == $"u{ID}")
                    {
                        control.MouseUp += TextBlock_MouseLeftButtonUp;
                        if (novy.Kreditni)
                        {
                            tb.Tag = novy.Ku;
                            tb.Text = $"{novy.Ku.Jmeno}      Aktuální částka: {novy.Ku.PocatecniUver}Kč     DETAIL";
                        }
                        else
                        {
                            tb.Tag = novy.Du;
                            tb.Text = $"{novy.Du.Jmeno}      Aktuální částka: {novy.Du.AktualniCastka}Kč     DETAIL";
                        }
                    }
                }
            }
        }
    }
}
