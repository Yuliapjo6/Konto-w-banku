using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class KontoPlus : Konto
    {
        public decimal limitDebetowy;
        private bool czyLimitWykorzystany = false;

        public KontoPlus(string klient, decimal bilansNaStart, decimal limit)
            : base(klient, bilansNaStart)
        {
            this.limitDebetowy = limit;
        }
        public override void Wyplata(decimal kwota)
        {
            if (zablokowane) throw new InvalidOperationException("Konto zablokowane.");

            if (kwota > bilans)
            {
                if (czyLimitWykorzystany) throw new InvalidOperationException("Limit już wykorzystany.");
                if (kwota > bilans + limitDebetowy) throw new InvalidOperationException("Przekroczono limit debetowy.");

                bilans -= kwota;
                czyLimitWykorzystany = true;
                BlokujKonto();
            }
            else
            {
                base.Wyplata(kwota);
            }
        }
        public override void Wplata(decimal kwota)
        {
            base.Wplata(kwota);
            if (bilans >= 0)
            {
                czyLimitWykorzystany = false;
                OdblokujKonto();
            }
        }
    }
}
