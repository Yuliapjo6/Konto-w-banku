using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    public class KontoLimit
    {
        private Konto mojeKonto;
        private decimal limit;
        private bool czyLimitWykorzystany = false;

        public KontoLimit(string klient, decimal bilansNaStart, decimal limit)
        {
            this.mojeKonto = new Konto(klient, bilansNaStart);
            this.limit = limit;
        }
        public decimal Bilans => mojeKonto.Bilans;
        public bool CzyZablokowane => mojeKonto.CzyZablokowane;

        public void Wplata(decimal kwota)
        {
            mojeKonto.Wplata(kwota);
            if (mojeKonto.Bilans >= 0)
            {
                czyLimitWykorzystany = false;
                mojeKonto.OdblokujKonto();
            }
        }
        public void Wyplata(decimal kwota)
        {
            if (mojeKonto.CzyZablokowane) throw new InvalidOperationException("Konto zablokowane.");

            if (kwota > mojeKonto.Bilans)
            {
                if (czyLimitWykorzystany) throw new InvalidOperationException("Limit wykorzystany.");
                if (kwota > mojeKonto.Bilans + limit) throw new InvalidOperationException("Za mały limit.");
            }
            else
            {
                mojeKonto.Wyplata(kwota);
            }
        }
    } 
}
