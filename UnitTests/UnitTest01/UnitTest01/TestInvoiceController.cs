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
    public class TestInvoiceController // Test alle methods in de ClientController
    {
        // Mock alle objecten, gebruikt in de class ClientController:
        private readonly Mock<IClientManager> _clientManager;
        private readonly Mock<IInvoiceManager> _invoiceManager;
        private readonly Mock<ILogger<InvoiceController>> _logger;

        // _ zelf niet mocken, maar wel naar interface (DI) laten wijzen: 
        private readonly InvoiceController _invoiceController;

        public TestInvoiceController()
        {
            _clientManager = new Mock<IClientManager>();
            _invoiceManager = new Mock<IInvoiceManager>();
            _logger = new Mock<ILogger<InvoiceController>>();

            _invoiceController = new InvoiceController(
                _logger.Object,
                 _invoiceManager.Object,
                _clientManager.Object
               );
        }

        [TestMethod]
        public void TestIndexVerify()
        {
            // Arrange
            Factory1.CreateMockedCountriesClientsInvoices
               (out List<Country> mockedCountryList,
               out List<Client> mockedClientList,
               out List<Invoice> mockedInvoiceList);

            var moqClient = mockedClientList[0];
            var moqInvoiceList = new List<Invoice>
            {
                mockedInvoiceList[0], mockedInvoiceList[1]
            };
            // Alleen bij aanroep met de moqClient wordt de moqInvoiceList terug gegeven:
            _invoiceManager.Setup(i => i.GetAll(moqClient.Id)).Returns(moqInvoiceList);
            // _invoiceManager.Setup(x => x.GetAll(It.IsAny<int>())).Returns(moqInvoiceList);  // kan ook
            _clientManager.Setup(c => c.GetClient(It.IsAny<int>())).Returns(moqClient);
            _clientManager.Setup(c => c.GetClient(moqClient.Id)).Returns(moqClient);

            // Didactisch: je kan met SetupGet ook een property faken: 
            _clientManager.SetupGet(c => c.StringVoorDidactischUnitTest).Returns("Molly");


            // Act
            var result = _invoiceController.Index(moqClient.Id);  // Type IActionResult
            var viewResult = (ViewResult)result; // Type ViewResult, bevat prop = Model
            var invoiceIndexVM = (InvoiceIndexVM)viewResult.Model;

            // Assert
            _clientManager.Verify((c => c.MultiplyClientNumberBy100(moqClient.Id)), Times.Exactly(3));
            _clientManager.Verify((c => c.MultiplyClientNumberBy100(1000)), Times.Never());
            _clientManager.Verify((c => c.MultiplyClientNumberBy100(moqClient.Id)), Times.AtLeast(1)); // Minimaal #keer
            _clientManager.Verify((c => c.MultiplyClientNumberBy100(moqClient.Id)), Times.AtMost(10)); // Maximaal #keer
            _clientManager.Verify((c => c.MultiplyClientNumberBy100(moqClient.Id)), Times.AtLeastOnce());

            // Onderstaande werkt niet? 
            // _clientManager.Verify((c => c.MultiplyClientNumberBy100(moqClient.Id)), Times.Between(0, 4, Moq.Range.Exclusive)); 

            _clientManager.Verify((c => c.MultiplyClientNumberBy100(moqClient.Id)), Times.Between(1, 3, Moq.Range.Inclusive));

            _clientManager.Verify(
                (c => c.DeleteClient(It.IsAny<int>())),
                Times.Never);

            Assert.AreEqual(moqInvoiceList.Count, invoiceIndexVM.ListOfItems.Count);
            Assert.AreEqual(2, invoiceIndexVM.ListOfItems.Count);


            var firstName = moqClient.FirstName;
            var lastName = moqClient.LastName;
            var fullNameClient = moqClient.FirstName + " " + moqClient.LastName;

            Assert.IsTrue(invoiceIndexVM.ClientFullName == fullNameClient);
            Assert.AreEqual(moqClient.ClientNumber, invoiceIndexVM.ClientNumber); 

        }
    }
}
