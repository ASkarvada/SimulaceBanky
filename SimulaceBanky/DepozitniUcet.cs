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

        public DepozitniUcet(string jmeno, double aktualniCastka, double urokZaRok, List<string> historie, DateTime datumUveru)
        {
            Jmeno = jmeno;
            AktualniCastka = aktualniCastka;
            RUM = urokZaRok;
            Historie = historie;
            DatumUveru = datumUveru;
        }

        public void PricteniUroku()
        {
            double MUM = RUM / 12;
            AktualniCastka += AktualniCastka * MUM * 0.85;
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

        public virtual string Podrobnosti(DateTime now)
        {
            DateTime submitDate = now.AddDays(27);

            return $@"Typ účtu: Spořící
Úročení: {RUM * 100}% za rok
Omezenost jednorázového výběru: Ne
Účet založen: {DatumUveru.Day}.{DatumUveru.Month}.{DatumUveru.Year}
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
                    if(i < (pole.Length - 1)) { t += " - "; }
                }
                t += "\n";
            }
            return t;
        }

        
    }

    public class StudentskyUcet : DepozitniUcet
    {
        public double OmezenostVyberu { get; set; }
        public StudentskyUcet(string jmeno, double aktualniCastka, double urokZaRok, List<string> historie, DateTime datumUveru, double omezenostVyberu) : base(jmeno, aktualniCastka, urokZaRok, historie, datumUveru)
        {
            OmezenostVyberu = omezenostVyberu;
        }

        public override string Podrobnosti(DateTime now)
        {
            DateTime submitDate = now.AddDays(27);

            return $@"Typ účtu: Spořící studentský
Úročení: {RUM * 100}% za rok
Omezenost jednorázového výběru: Ano - {OmezenostVyberu}Kč
Účet založen: {DatumUveru.Day}.{DatumUveru.Month}.{DatumUveru.Year}
Následující připsání úroku: 10.{submitDate.Month}.{submitDate.Year}";
        }
    }
}
