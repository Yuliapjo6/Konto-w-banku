namespace Bank
{
    public class Konto
    {
        protected string klient;  //nazwa klienta
        protected decimal bilans;  //aktualny stan środków na koncie
        protected bool zablokowane = false; //stan konta
        public Konto(string klient, decimal bilansNaStart = 0)
        {
            this.klient = klient;
            this.bilans = bilansNaStart;

        }
        public string Nazwa => klient;
        public decimal Bilans => bilans;
        public bool CzyZablokowane => zablokowane;

        public void BlokujKonto() => zablokowane = true;
        public void OdblokujKonto() => zablokowane = false;
        public virtual void Wplata(decimal kwota)
        {
            if (zablokowane) throw new InvalidOperationException("Nie można wpłacić pieniędzy na zablokowane konto.");
            if (kwota <= 0) throw new ArgumentOutOfRangeException(nameof(kwota), "Kwota wpłaty musi być dodatnia.");
            bilans += kwota;
        }
        public virtual void Wyplata(decimal kwota)
        {
            if (zablokowane) throw new InvalidOperationException("Nie można wypłacić pieniędzy na zablokowane konto.");
            if (kwota <= 0) throw new ArgumentOutOfRangeException(nameof(kwota), "Kwota wypłaty musi być dodatnia.");
            if (kwota > bilans) throw new InvalidOperationException("Brak wystarczających środków na koncie.");
            bilans -= kwota;
        }
    }
}
