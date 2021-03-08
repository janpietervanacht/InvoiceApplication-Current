using Model;
using System;
using System.Collections.Generic;

namespace TestFactory
{
    public static class Factory1
    {
        public static void CreateMockedCountriesClientsInvoices(
            out List<Country> mockedCountryList, out List<Client> mockedClientList, out List<Invoice> mockedInvoiceList)
        {
            var country1 = CreateCountry(1);
            var country2 = CreateCountry(2);
            var country3 = CreateCountry(3);
            var client1 = CreateClient(1);
            var client2 = CreateClient(2);
            var client3 = CreateClient(3);
            var client4 = CreateClient(4);
            var invoice1 = CreateInvoice(1);
            var invoice2 = CreateInvoice(2);
            var invoice3 = CreateInvoice(3);
            var invoice4 = CreateInvoice(4);
            var invoice5 = CreateInvoice(5);
            var invoice6 = CreateInvoice(6);
            var invoice7 = CreateInvoice(7);
            var invoice8 = CreateInvoice(8);
            AddCountryToClient(ref client1, country1);
            AddCountryToClient(ref client2, country2);
            AddCountryToClient(ref client3, country3);
            // Klant 4 kent geen land (immers: land is niet verplicht). 

            AddInvoiceToClient(ref client1, ref invoice1);
            AddInvoiceToClient(ref client1, ref invoice2);
            AddInvoiceToClient(ref client2, ref invoice3);
            AddInvoiceToClient(ref client2, ref invoice4);
            AddInvoiceToClient(ref client3, ref invoice5);
            AddInvoiceToClient(ref client3, ref invoice6);
            AddInvoiceToClient(ref client4, ref invoice7);
            AddInvoiceToClient(ref client4, ref invoice8);

            mockedCountryList = new List<Country>
            {
                country1, country2, country3
            };

            mockedClientList = new List<Client>
            {
                client1, client2, client3, client4
            };

            mockedInvoiceList = new List<Invoice>
            {
                invoice1, invoice2, invoice3, invoice4, invoice5, invoice6, invoice7, invoice8
            };

        }

        internal static Country CreateCountry(int countryId)
        {
            // Niet meer dan 99 countries

            var isoCode = countryId.ToString().PadLeft(2, '0');
            var result = new Country
            {
                Id = countryId,
                CountryDescription = $"Land met nummer is \'{isoCode}\'",
                CountryIsoCode = isoCode
            };
            return result;
        }

        internal static Client CreateClient
            (int clientId)
        {
            bool isInsured = false;
            bool isPopstar = false;
            int? popStarYearIncome = null;
            char gender = 'M';

            switch (clientId % 4)
            {
                case 0:
                    isInsured = false;
                    isPopstar = false;
                    popStarYearIncome = null;
                    gender = 'M';
                    break;
                case 1:
                    isInsured = false;
                    isPopstar = true;
                    popStarYearIncome = 700000 + clientId;
                    gender = 'V';
                    break;
                case 2:
                    isInsured = true;
                    isPopstar = false;
                    popStarYearIncome = null;
                    gender = 'M';
                    break;
                case 3:
                    isInsured = true;
                    isPopstar = true;
                    popStarYearIncome = 700000 + clientId;
                    gender = 'V';
                    break;
            }

            var result = new Client
            {
                Id = clientId,
                ActionCode = 'A',
                ClientNumber = 100000 + clientId,
                FirstName = $"Voornaam klant {100000 + clientId}",
                LastName = $"Achternaam klant {100000 + clientId}",
                BirthDate = new DateTime(1967, 11, 01).AddYears(clientId),
                IsInsured = isInsured,
                IsPopstar = isPopstar,
                PopstarYearIncome = popStarYearIncome,
                Gender = gender,
                CountryId = null, // komt misschien later, is nullable value variabele
                Country = null, // komt misschien later, land is niet verplicht 
                InvoiceList = new List<Invoice>()   // vullen komt later
            };
            return result;
        }

        internal static Invoice CreateInvoice
           (int invoiceId)
        {
            var result = new Invoice
            {
                Id = invoiceId,
                InvoiceNumber = 40000000 + invoiceId,
                ClientId = 0,   // komt later
                Client = null,  // komt later
                Status = 'O',
                InvoiceDate = DateTime.Now,
                Amount = (decimal)(400 + invoiceId + 0.25),
                DueDate = DateTime.Now.AddMonths(invoiceId),
                InvoiceDescription = $"Factuur {40000000 + invoiceId}",
                InvoiceSend = true,
            };
            return result;
        }

        internal static void AddCountryToClient(ref Client client, Country country)
        {
            client.CountryId = country.Id;
            client.Country = country;
        }

        internal static void AddInvoiceToClient(ref Client client, ref Invoice invoice)
        {
            invoice.ClientId = client.Id;
            invoice.Client = client;
            client.InvoiceList.Add(invoice);
        }

    }
}
