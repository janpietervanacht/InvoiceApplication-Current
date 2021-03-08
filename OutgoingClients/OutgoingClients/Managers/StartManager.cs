using OutgoingExports.DependencyInfra;
using System;
using Model.ConstantsAndEnums; 

namespace OutgoingExports.Managers
{
    internal class StartManager : IStartManager
    {
        private IOutgoingClientManager _outgoingClientManager;
        private IOutgoingInvoiceManager _outgoingInvoiceManager;

        public void StartBackGround()
        {
            // Deze class is niet static, omdat we enkele private variabelen willen setten.
            // Dependency injection doe je één keer, namelijk in de Start-manager
            // We moeten werken met de out variabelen, dat zijn allemaal nieuwe managers
            // Dit principe van out variabelen moet ook voor DI bij het Windows Forms MVC project

            Dependency.InitialiseerDI(ref _outgoingClientManager, ref _outgoingInvoiceManager);

            _outgoingClientManager.CreateOutgClientFile(SizeOfClientEnum.Big, TypeOfExport.XML);
            _outgoingClientManager.CreateOutgClientFile(SizeOfClientEnum.Small, TypeOfExport.JSON);
            _outgoingInvoiceManager.CreateOutgInvoiceFile(TypeOfExport.XML);
        }
    }
}
