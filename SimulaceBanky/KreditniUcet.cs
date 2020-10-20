using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulaceBanky
{
    class KreditniUcet
    {
        double AktualniCastka { get; set; }
        double PocatecniUver { get; set; }
        DateTime DatumUveru { get; set; } 
        int DobaSplatnosti { get; set; } 
        double RUM { get; set; } 
        double MinulaCastka { get; set; }
        
        List<string> Historie { get; set; }

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
    }
}
