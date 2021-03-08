using System.Collections.Generic;

namespace OutgoingInvoiceBatch.ModelsExport
{
    public class BaseExportFile<T>
    {

        public HeaderOutgoing HeaderOutgoing { get; set; }

        public List<T> LijstMetItems { get; set; }

        public FooterOutgoing FooterOutgoing { get; set; }
         
    }

    //----------------------------- 

    public class HeaderOutgoing
    {
        public string FileName { get; set; }
        public string Soort { get; set; }
        public string DateTimeExported { get; set; } // geformatteerde timestamp string
    }

    public class FooterOutgoing
    {
        public int NrofRecords { get; set; }
    }

}