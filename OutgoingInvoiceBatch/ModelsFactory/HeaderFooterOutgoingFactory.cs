using Model;
using OutgoingInvoiceBatch.ExportFileModels;
using OutgoingInvoiceBatch.ModelsExport;
using System;

namespace OutgoingInvoiceBatch.ModelsFactory
{
    public static class HeaderFooterOutgoingFactory<T>
    {

        public static HeaderOutgoing GetHeader(string fullFileName)
        {
            return new HeaderOutgoing
            {
                DateTimeExported = DateTime.Now.ToString("yyyyMMdd-HHmmss"),
                FileName = fullFileName,
                Soort = typeof(T).Name
            };
        }

        public static FooterOutgoing GetFooter(int nrOfRecords)
        {
            return new FooterOutgoing
            {
                NrofRecords = nrOfRecords
            };
        }

    }


}