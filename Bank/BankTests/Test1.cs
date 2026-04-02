using Bank;
using System;
namespace BankTests
{
    [TestClass]
    public class KontoTests
    {
        [TestMethod]
        public void Wplata_PoprawnaKwota_ZwiekszaBilans()
        {
            // Arrange
            var konto = new Konto("Jan Kowalski", 100);

            // Act
            konto.Wplata(50);

            // Assert
            Assert.AreEqual(150, konto.Bilans);
        }
        [TestMethod]
        public void Wyplata_ZablokowaneKonto_PowinnaRzucicWyjatek()
        {
            // Arrange
            var konto = new Konto("Jan Molenda", 100);
            konto.BlokujKonto();

            // Act & Assert
            try
            {
                konto.Wyplata(50);
                Assert.Fail("Wyjątek nie został rzucony, a powinien!");
            }
            catch (InvalidOperationException) { }
        }

        [TestMethod]
        public void Wyplata_PoprawnaKwota_ZmniejszaBilans()
        {
            // Arrange
            var konto = new Konto("Jan Molenda", 100);

            // Act
            konto.Wyplata(40);

            // Assert
            Assert.AreEqual(60, konto.Bilans);
        }
        [TestMethod]
        public void KontoPlus_Wyplata_WykorzystujeLimit_BlokujeKonto()
        {
            // Arrange
            var konto = new KontoPlus("Adam Nowak", 100, 50);

            // Act
            konto.Wyplata(130);

            // Assert
            Assert.AreEqual(-30, konto.Bilans);
            Assert.IsTrue(konto.CzyZablokowane, "Konto powinno zostać zablokowane");
        }
        [TestMethod]
        public void KontoLimit_Wyplata_DelegujeZadanieDoWewnetrznegoKonta()
        {
            // Arrange
            var konto = new KontoLimit("Anna Kowalska", 200, 100);

            // Act
            konto.Wyplata(50);

            // Assert
            Assert.AreEqual(150, konto.Bilans);
        }

        [TestMethod]
        public void KontoLimit_PrzekroczenieLimitu_RzucaWyjatek()
        {
            // Arrange
            var konto = new KontoLimit("Anna Kowalska", 100, 50);

            // Act & Assert
            try
            {
                konto.Wyplata(200);
                Assert.Fail("Powinien zostać rzucony wyjątek o przekroczeniu limitu!");
            }
            catch (InvalidOperationException){ }
        }
    }
}
