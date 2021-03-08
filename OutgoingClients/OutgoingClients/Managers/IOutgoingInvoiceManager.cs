using Model.ConstantsAndEnums;

namespace OutgoingExports.Managers
{
    public interface IOutgoingInvoiceManager
    {
        void CreateOutgInvoiceFile(TypeOfExport typeOfExport);
    }
}