using Model.ConstantsAndEnums;

namespace OutgoingExports.Managers
{
    public interface IOutgoingClientManager
    {
        void CreateOutgClientFile(SizeOfClientEnum typeOfClient, TypeOfExport typeOfExport);
    }
}