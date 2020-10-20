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
        public double AktualniCastka { get; set; }
        double RUM { get; set; }
        public List<string> Historie { get; set; }
        DateTime DatumUveru { get; set; }
        int DobaSplatnosti { get; set; }

        public DepozitniUcet(double aktualniCastka, double urokZaRok, List<string> historie, DateTime datumUveru, int dobaSplatnoti)
        {
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

    }

    public class StudentskyUcet : DepozitniUcet
    {
        double OmezenostVyberu { get; set; }
        public StudentskyUcet(double aktualniCastka, double urokZaRok, List<string> historie, DateTime datumUveru, int dobaSplatnoti, double omezenostVyberu) : base(aktualniCastka, urokZaRok, historie, datumUveru, dobaSplatnoti)
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
    }
}
