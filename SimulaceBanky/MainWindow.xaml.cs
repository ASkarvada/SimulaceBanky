using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using System.Xml;
using System.Xml.Serialization;

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
        public DispatcherTimer Timmy { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            ID = 0;
            Datum = DateTime.Now;
            tbl_datum.Text = Datum.ToString("dd.MM.yyyy");
            Penize = Convert.ToDouble(tbl_penize.Text);

            Timmy = new DispatcherTimer();
            Timmy.Tick += new EventHandler(timmy_Tick);
            Timmy.Interval = new TimeSpan(0, 0, 2);
            Timmy.Start();
        }

        private void timmy_Tick(object sender, EventArgs e)
        {
            Datum = Datum.AddDays(1);
            tbl_datum.Text = Datum.ToString("dd.MM.yyyy");
            if (Datum.Day == 10) Urokovani();
        }

        private void Urokovani()
        {
            bool zurokovano = false;
            foreach (UIElement control in st.Children)
            {
                if (control.GetType() == typeof(TextBlock))
                {
                    TextBlock tb = control as TextBlock;
                    StudentskyUcet su = new StudentskyUcet("",0,0,new List<string>(),new DateTime(),0);
                    KreditniUcet ku = new KreditniUcet("", 0, 0, new List<string>(), new DateTime(), 0, new DateTime());
                    DepozitniUcet du = new DepozitniUcet("", 0, 0, new List<string>(), new DateTime());

                    control.MouseUp += TextBlock_MouseLeftButtonUp;
                    if (tb.Tag is KreditniUcet)
                    {
                        ku = (KreditniUcet)tb.Tag;
                        ku.OdecteniUroku();
                    }
                    else if (tb.Tag is DepozitniUcet && !(tb.Tag is StudentskyUcet))
                    {
                        du = (DepozitniUcet)tb.Tag;
                        du.PricteniUroku();
                    }
                    else if (tb.Tag is StudentskyUcet)
                    {
                        su = (StudentskyUcet)tb.Tag;
                        su.PricteniUroku();
                    }
                    AktualizaceIkonyUctu(ku, du, su, tb.Tag);
                    zurokovano = true;
                }
            }
            tbl_penize.Text = Penize.ToString();
            if(zurokovano)MessageBox.Show("Byli Vám připsány úroky", "Splátkové období");
        }

        private void TextBlock_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Timmy.Stop();

            TextBlock tbl = sender as TextBlock;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Timmy.Stop();
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
                            string d = $"Možnost výběru: {novy.Ku.PocatecniUver}Kč";
                            tb.Text = string.Format("{0}{1}{2}", name.PadRight(40), ak.PadRight(40), d);
                        }
                        else if (novy.Typ == "D")
                        {
                            tb.Tag = novy.Du;
                            string name = novy.Du.Jmeno;
                            string ak = $"Aktuální částka: {novy.Du.AktualniCastka}Kč";
                            //string d = "DETAIL";
                            tb.Text = string.Format("{0}{1}", name.PadRight(40), ak.PadRight(50));
                            
                        }
                        else if (novy.Typ == "S")
                        {
                            tb.Tag = novy.Su;
                            string name = novy.Su.Jmeno;
                            string ak = $"Aktuální částka: {novy.Su.AktualniCastka}Kč";
                            //string d = "DETAIL";
                            tb.Text = string.Format("{0}{1}", name.PadRight(40), ak.PadRight(50));

                        }
                    }
                }
            }
            tbl_penize.Text = Penize.ToString();
            Timmy.Start();
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
                            string name = ku.Jmeno;
                            string ak = $"Aktuální částka: {ku.AktualniCastka}Kč";
                            string d = $"Možnost výběru: {(ku.PocatecniUver + ku.AktualniCastka)}Kč";
                            tb.Text = string.Format("{0}{1}{2}", name.PadRight(40), ak.PadRight(50), d);
                        }
                        else if (tag is DepozitniUcet && !(tag is StudentskyUcet))
                        {
                            tb.Tag = dp;
                            string name = dp.Jmeno;
                            string ak = $"Aktuální částka: {dp.AktualniCastka}Kč";
                            //string d = "DETAIL";
                            tb.Text = string.Format("{0}{1}", name.PadRight(40), ak.PadRight(50));
                        }
                        else if (tag is StudentskyUcet)
                        {
                            tb.Tag = su;
                            string name = su.Jmeno;
                            string ak = $"Aktuální částka: {su.AktualniCastka}Kč";
                            //string d = "DETAIL";
                            tb.Text = string.Format("{0}{1}", name.PadRight(40), ak.PadRight(50));
                        }
                    }
                }
            }
            tbl_penize.Text = Penize.ToString();
            Timmy.Start();
        }

        public void SmazatUcet(object tag)
        {
            foreach (UIElement control in st.Children)
            {
                if (control.GetType() == typeof(TextBlock))
                {
                    TextBlock tb = control as TextBlock;
                    if (tb.Tag == tag)
                    {
                        st.Children.Remove(control);
                        return;
                    }
                }
            }
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

        private void tbl_plusDatum_Click(object sender, RoutedEventArgs e)
        {
            Datum = Datum.AddDays(1);
            tbl_datum.Text = Datum.ToString("dd.MM.yyyy");
            if (Datum.Day == 10) Urokovani();
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            
        }
        

        
    }
}
