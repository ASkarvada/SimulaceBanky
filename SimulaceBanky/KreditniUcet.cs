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
        public double MinulaCastka { get; set; }

        public List<string> Historie { get; set; }

        public KreditniUcet(string jmeno, double pocatecniUver, double urokZaRok, List<string> historie, DateTime datumUveru, int dobaSplatnosti, DateTime konecUveru)
        {
            Jmeno = jmeno;
            AktualniCastka = pocatecniUver;
            PocatecniUver = pocatecniUver; 
            RUM = urokZaRok;
            Historie = historie;
            MinulaCastka = AktualniCastka; //ošetřit toto
            DatumUveru = datumUveru;
            KonecUveru = konecUveru;
            DobaSplatnosti = dobaSplatnosti;
        }

        public double OdecteniUroku() 
        {
            double MUM =  RUM / 12;
            MinulaCastka = MinulaCastka * MUM * 0.85;
            return MinulaCastka;
        }

        public void PraceSUctem(bool vklad, double castka, string text, DateTime aktualniDatum)
        {
            if (vklad)
            {
                string t = $"VKLAD*{aktualniDatum.ToString("dd.m.yyyy")}*{castka}Kč*{text}";
                AktualniCastka += castka;
                Historie.Add(t);
            }
            else
            {
                string t = $"VÝBĚR*{aktualniDatum.ToString("dd.m.yyyy")}*{castka}Kč*{text}";
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
