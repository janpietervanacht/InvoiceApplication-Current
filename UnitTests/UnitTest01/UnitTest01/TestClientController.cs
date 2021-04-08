using Business.Interfaces;
using InvoiceMVC.Controllers;
using InvoiceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using System;
using System.Collections.Generic;
using TestFactory;

namespace UnitTest.TestMVCApp
{
    [TestClass]
    public class TestClientController // Test alle methods in de ClientController
    {
        // Mock alle objecten, gebruikt in de class ClientController:
        private readonly Mock<IClientManager> _clientManager;
        private readonly Mock<IInvoiceManager> _invoiceManager;
        private readonly Mock<ICountryManager> _countryManager;
        private readonly Mock<ILogger<ClientController>> _logger;

        // _ De te testen class: 
        private readonly ClientController _clientController;

        public TestClientController()
        {
            _clientManager = new Mock<IClientManager>();
            _invoiceManager = new Mock<IInvoiceManager>();
            _countryManager = new Mock<ICountryManager>();
            _logger = new Mock<ILogger<ClientController>>();

            _clientController = new ClientController(
                _logger.Object,
                _clientManager.Object,
                _countryManager.Object,
                _invoiceManager.Object); 
        }

        [TestMethod]
        public void TestIndex()
        {
            // Arrange

            Factory1.CreateMockedCountriesClientsInvoices
                (out List<Country> mockedCountryList, 
                out List<Client> mockedClientList, 
                out List<Invoice> mockedInvoiceList);

            // Je hoeft niet alle methods van de gemockte objecten te setuppen
            // Als je een method van ee mocked class geen Setup geeft, retourneert de method de DEFAULT waarde
            // (0 voor int, null voor een object, Jezus's geboortedatum voor een DateTime, etc) 

            _clientManager.Setup(x => x.GetAllClientsWithoutInvoices()).Returns(mockedClientList);
            _countryManager.Setup(x => x.GetAll()).Returns(mockedCountryList);
            _invoiceManager.Setup(x => x.CountNrOfInvoices(1)).Returns(100);
            _invoiceManager.Setup(x => x.CountNrOfInvoices(2)).Returns(200);
            _invoiceManager.Setup(x => x.CountNrOfInvoices(3)).Returns(3000);
            _invoiceManager.Setup(x => x.CountNrOfInvoices(4)).Returns(40000);

            // Act
            var result = _clientController.Index();  // Type IActionResult
            var viewResult = (ViewResult)result; // Type ViewResult, bevat prop = Model
            var clientIndexVM = (ClientIndexVM)viewResult.Model;

            // Assert
            Assert.AreEqual(4, clientIndexVM.ListOfItems.Count);
            Assert.IsTrue(clientIndexVM.ListOfItems[0].NumberOfInvoices == 100);
            Assert.IsTrue(clientIndexVM.ListOfItems[1].NumberOfInvoices == 200);
            Assert.IsTrue(clientIndexVM.ListOfItems[2].NumberOfInvoices == 3000);
            Assert.AreEqual(40000, clientIndexVM.ListOfItems[3].NumberOfInvoices);

            // AddInvoice() wordt nooit aangeroepen
            _invoiceManager.Verify(i => i.AddInvoice(It.IsAny<Invoice>()), Times.Exactly(0));
            // DrieKeerZinloos() wordt 3 keer door _invoiceManager aangeroepen

            _invoiceManager.Verify(i => i.DrieKeerZinloos(It.IsAny<int>()), Times.AtMost(3)); 

            // Klant 1 heeft wel een land
            Assert.AreNotEqual(null, clientIndexVM.ListOfItems[0].Client.CountryId);
            // Klant 2 heeft wel een land
            Assert.AreNotEqual(null, clientIndexVM.ListOfItems[1].Client.Country);
            Assert.IsTrue(clientIndexVM.ListOfItems[1].Client.CountryId.HasValue);

            // Klant 4 heeft geen land
            Assert.AreEqual(null, clientIndexVM.ListOfItems[3].Client.Country);
            // Klant 4 heeft geen land, dus GetValueOrDefault is 0
            Assert.AreEqual(0, clientIndexVM.ListOfItems[3].Client.CountryId.GetValueOrDefault());
            Assert.IsFalse(clientIndexVM.ListOfItems[3].Client.CountryId.HasValue);

        }

        [TestMethod]
        public void DetailsTestNoCountry()
        {
            // Arrange
            Factory1.CreateMockedCountriesClientsInvoices
                (out List<Country> mockedCountryList,
                out List<Client> mockedClientList,
                out List<Invoice> mockedInvoiceList);

            // Client 4 heeft geen land
            var client4 = mockedClientList[3];  // heeft geen land

            // Didactisch hieronder: de syntax van een SetUp met één parameterwaarde: 
             _clientManager.Setup(c => c.MultiplyClientNumberBy100(client4.ClientNumber)).Returns(200); 

            _clientManager.Setup(c => c.GetClient(It.IsAny<int>())).Returns(client4);

            // Act
            var result = _clientController.Details(1);  // result heeft Type IActionResult
            var viewResult = (ViewResult)result; // Type ViewResult, bevat prop = Model
            var clientVM = (ClientVM) viewResult.Model;

            var countryDescription = clientVM.ListOfCountries[0].CountryDescription;
            // Assert
            Assert.AreEqual(1, clientVM.ListOfCountries.Count);
            Assert.IsFalse(clientVM.Client == null);
            Assert.IsTrue(clientVM.Client.Country == null);
            Assert.AreEqual(null, clientVM.Client.CountryId);
            Assert.IsNull(clientVM.Client.CountryId);
            Assert.IsTrue(countryDescription.Contains($"has no country", StringComparison.CurrentCultureIgnoreCase));

        }
    }
}
