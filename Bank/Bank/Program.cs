using System;
using System.Collections.Generic;
using System.Text;

namespace Bank
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Symulacja Systemu Bankowego\n");

            // Test KontoPlus
            Console.WriteLine("KontoPlus (Jan Molenda, Saldo: 100, Limit: 50)");
            KontoPlus kp = new KontoPlus("Jan Molenda", 100, 50);

            Console.WriteLine("Wypłata 130 zł...");
            kp.Wyplata(130);
            Console.WriteLine($"Bilans po: {kp.Bilans}, Czy zablokowane: {kp.CzyZablokowane}");

            // Test KontoLimit
            Console.WriteLine("KontoLimit (Anna Nowak, Saldo: 200, Limit: 100)");
            KontoLimit kl = new KontoLimit("Anna Nowak", 200, 100);

            Console.WriteLine("Wypłata 250 zł...");
            kl.Wyplata(250);
            Console.WriteLine($"Bilans po: {kl.Bilans}, Czy zablokowane: {kl.CzyZablokowane}");

            Console.WriteLine("\nKoniec Symulacji");
            Console.WriteLine("Naciśnij dowolny klawisz, aby wyjść...");
            Console.ReadKey();
        }
    }
}
