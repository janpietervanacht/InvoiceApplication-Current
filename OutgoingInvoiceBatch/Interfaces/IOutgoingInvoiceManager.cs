using System;
using System.Collections.Generic;
using System.Text;

namespace OutgoingInvoiceBatch.Interfaces
{
    public interface IOutgoingInvoiceManager
    {
        string CreateOutgBigInvoiceFile();
        string CreateOutgSmallInvoiceFile();

    }
}

 