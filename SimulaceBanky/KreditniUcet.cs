using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulaceBanky
{
    public class KreditniUcet
    {
        public string Jmeno { get; set; }
        public double AktualniCastka { get; set; }
        public double PocatecniUver { get; set; }
        public DateTime DatumUveru { get; set; }
        public DateTime KonecUveru { get; set; }
        public int DobaSplatnosti { get; set; }
        public double RUM { get; set; }
        public int Nesplatky { get; set; }

        public List<string> Historie { get; set; }

        public KreditniUcet(string jmeno, double pocatecniUver, double urokZaRok, List<string> historie, DateTime datumUveru, int dobaSplatnosti, DateTime konecUveru)
        {
            Jmeno = jmeno;
            AktualniCastka = 0;
            PocatecniUver = pocatecniUver; 
            RUM = urokZaRok;
            Historie = historie;
            Nesplatky = 1;
            DatumUveru = datumUveru;
            KonecUveru = konecUveru;
            DobaSplatnosti = dobaSplatnosti;
        }

        public void OdecteniUroku() 
        {
            double MUM =  RUM / 12;
            if(PocatecniUver + AktualniCastka <= 0)
            {
                AktualniCastka -= Math.Abs(AktualniCastka) * MUM * Nesplatky * 0.85;
                Nesplatky++;
            }
            else
            {
                AktualniCastka -= Math.Abs(AktualniCastka) * MUM * 0.85;
                Nesplatky = 0;
            }
            AktualniCastka = Math.Round(AktualniCastka, 2);
        }

        public void PraceSUctem(bool vklad, double castka, string text, DateTime aktualniDatum)
        {
            if (vklad)
            {
                string t = $"VKLAD*{aktualniDatum.ToString("dd.MM.yyyy")}*{castka}Kč*{text}";
                AktualniCastka += castka;
                Historie.Add(t);
            }
            else
            {
                string t = $"VÝBĚR*{aktualniDatum.ToString("dd.MM.yyyy")}*{castka}Kč*{text}";
                AktualniCastka -= castka;
                Historie.Add(t);
            }

        }

        public string Podrobnosti(DateTime now)
        {
            int span = (KonecUveru.Month - now.Month) + 12 * (KonecUveru.Year - now.Year);
            DateTime submitDate = now.AddDays(27);

            return $@"Typ účtu: Úvěrový
Úročení: {RUM * 100}% za rok
Omezenost jednorázového výběru: Ne
Účet založen: {DatumUveru.Day}.{DatumUveru.Month}.{DatumUveru.Year}
Doba splatnosti: {DobaSplatnosti} měsíce
Poslední plánovaná splátka: {KonecUveru.Month}.{KonecUveru.Year}
Počet zbývajících splátek: {span}
Následující připsání úroku: 10.{submitDate.Month}.{submitDate.Year}";
        }

        public string VypisHistorie()
        {
            string t = "";
            foreach (var item in Historie)
            {
                string[] pole = item.Split('*');
                for (int i = 0; i < pole.Length; i++)
                {
                    t += pole[i];
                    if (i < (pole.Length - 1)) { t += " - "; }
                }
                t += "\n";
            }
            return t;
        }
    }
}
