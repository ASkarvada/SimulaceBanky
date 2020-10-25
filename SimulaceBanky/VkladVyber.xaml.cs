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
    /// Interakční logika pro VkladVyber.xaml
    /// </summary>
    public partial class VkladVyber : Window
    {
        DetailUctu D { get; set; }
        bool Vklad { get; set; }

        public VkladVyber(DetailUctu d, bool vklad)
        {
            InitializeComponent();
            D = d;
            Vklad = vklad;

            tbl_castkaHotovost.Text = d.Penize.ToString();
            tbl_castkaUcet.Text = d.tbl_castka.Text;

            if (d.StaryTag is StudentskyUcet)
            {
                tbl_omezenost.Text = d.Su.OmezenostVyberu.ToString() + "Kč";
            }
            else if(d.StaryTag is KreditniUcet)
            {
                tbl_castkaUcet.Text = (d.Ku.PocatecniUver + d.Ku.AktualniCastka).ToString();
                tbl_omezenost.Text = "Omezenost úvěrem";
            }
            else
            {
                tbl_omezenost.Text = "Omezenost zůstatkem";
            }

            if (vklad)
            { tbl_jmeno.Text = "Vklad"; b_vkladVyber.Content = "Provést vklad"; }
            else { tbl_jmeno.Text = "Výběr"; b_vkladVyber.Content = "Provést výběr"; }
        }

        
        private void b_vkladVyber_Click_1(object sender, RoutedEventArgs e)
        {
            if (Vklad)
            {
                if (Convert.ToDouble(tbl_castkaHotovost.Text) >= Convert.ToDouble(tbl_castkaVyberu.Text))
                {
                    if (D.StaryTag is StudentskyUcet)
                    {
                        D.Penize -= Convert.ToDouble(tbl_castkaVyberu.Text);
                        D.Su.PraceSUctem(true, Convert.ToDouble(tbl_castkaVyberu.Text), tbl_poznamka.Text, D.Now);
                        MessageBox.Show($"Úspěšně jste vložili {Convert.ToDouble(tbl_castkaVyberu.Text)}Kč", "Potvrzení vkladu");

                        D.Opening("S");
                        this.Close();
                    }
                    else if (D.StaryTag is KreditniUcet)
                    {

                        D.Penize -= Convert.ToDouble(tbl_castkaVyberu.Text);
                        D.Ku.PraceSUctem(true, Convert.ToDouble(tbl_castkaVyberu.Text), tbl_poznamka.Text, D.Now);
                        MessageBox.Show($"Úspěšně jste vložili {Convert.ToDouble(tbl_castkaVyberu.Text)}Kč", "Potvrzení vkladu");

                        D.Opening("K");
                        this.Close();
                    }
                    else if (D.StaryTag is DepozitniUcet)
                    {
                        D.Penize -= Convert.ToDouble(tbl_castkaVyberu.Text);
                        D.Dp.PraceSUctem(true, Convert.ToDouble(tbl_castkaVyberu.Text), tbl_poznamka.Text, D.Now);
                        MessageBox.Show($"Úspěšně jste vložili {Convert.ToDouble(tbl_castkaVyberu.Text)}Kč", "Potvrzení vkladu");

                        D.Opening("D");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Nemáte dostatek prostředků k provedení vkladu!", "Chyba");
                }
            }
            else
            {
                if (Convert.ToDouble(tbl_castkaUcet.Text) >= Convert.ToDouble(tbl_castkaVyberu.Text))
                {
                    if (D.StaryTag is StudentskyUcet)
                    {
                        if(Convert.ToDouble(tbl_castkaVyberu.Text) <= D.Su.OmezenostVyberu)
                        {
                            D.Penize += Convert.ToDouble(tbl_castkaVyberu.Text);
                            D.Su.PraceSUctem(false, Convert.ToDouble(tbl_castkaVyberu.Text), tbl_poznamka.Text, D.Now);
                            MessageBox.Show($"Úspěšně jste vybrali {Convert.ToDouble(tbl_castkaVyberu.Text)}Kč", "Potvrzení výběru");
                            D.Opening("S");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show($"Váš účet má nastavenou omezenost na {D.Su.OmezenostVyberu}Kč, nemůžete vybírat více", "Chyba");
                        }
                        
                    }
                    else if (D.StaryTag is KreditniUcet)
                    {
                        D.Penize += Convert.ToDouble(tbl_castkaVyberu.Text);
                        D.Ku.PraceSUctem(false, Convert.ToDouble(tbl_castkaVyberu.Text), tbl_poznamka.Text, D.Now);
                        MessageBox.Show($"Úspěšně jste vybrali {Convert.ToDouble(tbl_castkaVyberu.Text)}Kč", "Potvrzení výběru");
                        D.Opening("K");
                        this.Close();
                    }
                    else if (D.StaryTag is DepozitniUcet)
                    {
                        D.Penize += Convert.ToDouble(tbl_castkaVyberu.Text);
                        D.Dp.PraceSUctem(false, Convert.ToDouble(tbl_castkaVyberu.Text), tbl_poznamka.Text, D.Now);
                        MessageBox.Show($"Úspěšně jste vybrali {Convert.ToDouble(tbl_castkaVyberu.Text)}Kč", "Potvrzení výběru");
                        D.Opening("D");
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Nemáte dostatek prostředků na Vašem účtu k provedení výběru", "Chyba");
                }
            }
        }

        private void b_zrusit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
