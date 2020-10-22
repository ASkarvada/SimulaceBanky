using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimulaceBanky
{
    public class DepozitniUcet
    {
        public string Jmeno { get; set; }
        public double AktualniCastka { get; set; }
        public double RUM { get; set; }
        public List<string> Historie { get; set; }
        public DateTime DatumUveru { get; set; }
        public int DobaSplatnosti { get; set; }

        public DepozitniUcet(string jmeno, double aktualniCastka, double urokZaRok, List<string> historie, DateTime datumUveru, int dobaSplatnoti)
        {
            Jmeno = jmeno;
            AktualniCastka = aktualniCastka;
            RUM = urokZaRok;
            Historie = historie;
            DatumUveru = datumUveru;
            DobaSplatnosti = dobaSplatnoti;
        }

        public double PricteniUroku()
        {
            double MUM = RUM / 12;
            return AktualniCastka * MUM * 0.85;
        }

        public virtual void PraceSUctem(bool vklad, double castka, string text, DateTime aktualniDatum)
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
            return $@"Typ účtu: Spořící
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

    public class StudentskyUcet : DepozitniUcet
    {
        double OmezenostVyberu { get; set; }
        public StudentskyUcet(string jmeno, double aktualniCastka, double urokZaRok, List<string> historie, DateTime datumUveru, int dobaSplatnoti, double omezenostVyberu) : base(jmeno, aktualniCastka, urokZaRok, historie, datumUveru, dobaSplatnoti)
        {
            OmezenostVyberu = omezenostVyberu;
        }

        public override void PraceSUctem(bool vklad, double castka, string text, DateTime aktualniDatum)
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
            return $@"Typ účtu: Spořící studentský
Úročení: {RUM * 100}% za rok
Omezenost jednorázového výběru: Ano - {OmezenostVyberu}";
        }
    }
}
