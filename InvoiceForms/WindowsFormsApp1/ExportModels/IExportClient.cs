using System;

namespace InvoiceForms.ExportModels
{
    public interface IExportClient
    {
        public DateTime DateTimeCreated { get; set; }
    }
}
