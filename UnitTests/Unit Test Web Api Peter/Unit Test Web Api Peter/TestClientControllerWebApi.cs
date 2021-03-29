using DataAccess.Interfaces;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using System.Collections.Generic;
using TestFactory;
using WebApiPeterOrigineel.Controllers;

namespace UnitTestWebApiPeter
{
    [TestClass]
    public class TestClientsController 
    {
        private readonly Mock<IClientRepository> _clientRepository;
        private readonly Mock<IInvoiceRepository> _invoiceRepository;
        private readonly Mock<ICountryRepository> _countryRepository;
        private readonly Mock<ILogger<ClientsController>> _logger;

        // De te testen class = ClientsController:
        private readonly ClientsController _clientsController;

        public TestClientsController()
        {
            _clientRepository = new Mock<IClientRepository>();
            _invoiceRepository = new Mock<IInvoiceRepository>();
            _countryRepository = new Mock<ICountryRepository>();
            _logger = new Mock<ILogger<ClientsController>>();

            _clientsController = new ClientsController(
               _clientRepository.Object,
               _countryRepository.Object,
               _invoiceRepository.Object,
               _logger.Object);
        } 


        [TestMethod]
        public void TestGetStatistics()
        {
            // Arrange

            Factory1.CreateMockedCountriesClientsInvoices
                (out List<Country> mockedCountryList,
                out List<Client> mockedClientList,
                out List<Invoice> mockedInvoiceList);
          
            var client4 = mockedClientList[3];   // heeft geen land

            _clientRepository.Setup(x => x.GetByClientNumber(It.IsAny<int>())).Returns(client4);
            _invoiceRepository.Setup(i => i.CountNrOfInvoices(It.IsAny<int>())).Returns(10);

            // Act
            var dTOClientStatistics = _clientsController.GetStatisticsByClientNumber(client4.ClientNumber);

            // Assert

            Assert.AreEqual(10, dTOClientStatistics.AantalFacturen);
            Assert.AreEqual(21, dTOClientStatistics.AantalLettersAchterNaamKlantZonderSpaties);

            Assert.IsTrue(dTOClientStatistics.FactuurNummers[0] == "40000007");
            Assert.IsTrue(dTOClientStatistics.FactuurNummers[1] == "40000008");

            // 815,50
            Assert.AreEqual(815.5m, dTOClientStatistics.TotaalFactuurBedrag);
            _clientRepository.Verify(c => c.GetByClientNumber(client4.ClientNumber), Times.Exactly(2)); 



        }
    }
}
