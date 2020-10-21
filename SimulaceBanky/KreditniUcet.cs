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
        public int DobaSplatnosti { get; set; }
        public double RUM { get; set; }
        public double MinulaCastka { get; set; }

        public List<string> Historie { get; set; }

        public KreditniUcet(double pocatecniUver, double urokZaRok, List<string> historie, DateTime datumUveru, int dobaSplatnosti)
        {
            AktualniCastka = pocatecniUver;
            PocatecniUver = pocatecniUver; 
            RUM = urokZaRok;
            Historie = historie;
            MinulaCastka = AktualniCastka; //ošetřit toto
            DatumUveru = datumUveru;
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
                string t = $"vklad*{castka}*{text}*{aktualniDatum}";
                AktualniCastka += castka;
                Historie.Add(t);
            }
            else
            {
                string t = $"vyber*{castka}*{text}*{aktualniDatum}";
                AktualniCastka -= castka;
                Historie.Add(t);
            }

        }

        public override string ToString()
        {
            return $@"Typ účtu: Úvěrový
Úročení: {RUM * 100}% za rok
Omezenost jednorázového výběru: Ne";
        }

        public string VypisHistorie()
        {
            string t = "";
            foreach (var item in Historie)
            {
                t += item + "\n";
            }
            return t;
        }
    }
}
