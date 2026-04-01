using Bank;

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

            // Act
            konto.Wyplata(50);
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

    }
}
