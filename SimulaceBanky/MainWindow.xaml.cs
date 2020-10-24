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
        public DateTime Datum { get; set; }
        public double Penize { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ID = 0;
            Datum = DateTime.Now;
            Penize = Convert.ToDouble(tbl_penize.Text);
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock tbl = sender as TextBlock;
            if (tbl.Tag is KreditniUcet)
            {
                bool isWindowOpen = false;

                foreach (Window w in Application.Current.Windows)
                {
                    if (w is DetailUctu)
                    {
                        isWindowOpen = true;
                        w.Activate();
                    }
                }

                if (!isWindowOpen)
                {
                    DetailUctu novy = new DetailUctu(tbl.Tag, this, Datum, Penize);
                    novy.Show();
                }
            }
            else if (tbl.Tag is DepozitniUcet)
            {
                bool isWindowOpen = false;

                foreach (Window w in Application.Current.Windows)
                {
                    if (w is DetailUctu)
                    {
                        isWindowOpen = true;
                        w.Activate();
                    }
                }

                if (!isWindowOpen)
                {
                    DetailUctu novy = new DetailUctu(tbl.Tag, this, Datum, Penize);
                    novy.Show();
                }
                
            }
            else if (tbl.Tag is StudentskyUcet)
            {
                bool isWindowOpen = false;

                foreach (Window w in Application.Current.Windows)
                {
                    if (w is DetailUctu)
                    {
                        isWindowOpen = true;
                        w.Activate();
                    }
                }

                if (!isWindowOpen)
                {
                    DetailUctu novy = new DetailUctu(tbl.Tag, this, Datum, Penize);
                    novy.Show();
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PridaniUctu novy = new PridaniUctu(Datum, this);
            novy.Show();
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
                        if (novy.Typ == "K")
                        {
                            tb.Tag = novy.Ku;
                            string name = novy.Ku.Jmeno;
                            string ak = $"Aktuální částka: {novy.Ku.AktualniCastka}Kč";
                            string d = "DETAIL";
                            tb.Text = string.Format("{0}{1}{2}", name.PadRight(40), ak.PadRight(50), d);
                        }
                        else if (novy.Typ == "D")
                        {
                            tb.Tag = novy.Du;
                            string name = novy.Du.Jmeno;
                            string ak = $"Aktuální částka: {novy.Du.AktualniCastka}Kč";
                            string d = "DETAIL";
                            tb.Text = string.Format("{0}{1}{2}", name.PadRight(40), ak.PadRight(50), d);
                            
                        }
                        else if (novy.Typ == "S")
                        {
                            tb.Tag = novy.Su;
                            string name = novy.Su.Jmeno;
                            string ak = $"Aktuální částka: {novy.Su.AktualniCastka}Kč";
                            string d = "DETAIL";
                            tb.Text = string.Format("{0}{1}{2}", name.PadRight(40), ak.PadRight(50), d);

                        }
                    }
                }
            }
            tbl_penize.Text = Penize.ToString();
        }

        public void AktualizaceIkonyUctu(KreditniUcet ku, DepozitniUcet dp, StudentskyUcet su, object tag)
        {
            foreach (UIElement control in st.Children)
            {
                if (control.GetType() == typeof(TextBlock))
                {
                    TextBlock tb = control as TextBlock;
                    if (tb.Tag == tag)
                    {
                        control.MouseUp += TextBlock_MouseLeftButtonUp;
                        if (tag is KreditniUcet)
                        {
                            tb.Tag = ku;
                            //tb.Text = $"{novy.Ku.Jmeno} Aktuální částka: {novy.Ku.PocatecniUver}Kč DETAIL";
                            string name = ku.Jmeno;
                            string ak = $"Aktuální částka: {ku.AktualniCastka}Kč";
                            string d = "DETAIL";
                            tb.Text = string.Format("{0}{1}{2}", name.PadRight(40), ak.PadRight(50), d);
                        }
                        else if (tag is DepozitniUcet)
                        {
                            tb.Tag = dp;
                            string name = dp.Jmeno;
                            string ak = $"Aktuální částka: {dp.AktualniCastka}Kč";
                            string d = "DETAIL";
                            tb.Text = string.Format("{0}{1}{2}", name.PadRight(40), ak.PadRight(50), d);
                        }
                        else if (tag is DepozitniUcet)
                        {
                            tb.Tag = su;
                            string name = su.Jmeno;
                            string ak = $"Aktuální částka: {su.AktualniCastka}Kč";
                            string d = "DETAIL";
                            tb.Text = string.Format("{0}{1}{2}", name.PadRight(40), ak.PadRight(50), d);
                        }
                    }
                }
            }
            tbl_penize.Text = Penize.ToString();
        }


        private void tbl_plus_Click(object sender, RoutedEventArgs e)
        {
            Penize += 1000;
            tbl_penize.Text = Penize.ToString();
        }

        private void tbl_minus_Click(object sender, RoutedEventArgs e)
        {
            Penize -= 1000;
            tbl_penize.Text = Penize.ToString();
        }
    }
}
