using System;
using System.Collections.Generic;

namespace InvoiceForms.ExportModels
{
    [Serializable]
    public class ExportClientList<T> where T: BaseClient, IExportClient
    {
        public Header Header { get; set; }
        public List<T> ClientList { get; set; }
        public Footer Footer { get; set; }
    }

    public class Header
    {
        public string FileName { get; set; }
        public DateTime DateTimeCreated { get; set; }
        public string TypeOfElement { get; set; }  // BigClient of SmallClient
    }

    public class Footer
    {
        public int nrOfRecords { get; set; }
    }
}
