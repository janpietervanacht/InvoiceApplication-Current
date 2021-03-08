using OutgoingExports;
using System.Threading.Tasks;

namespace InvoiceMVC.Asynchronous
{
    public class ASyncProcesses
    {
        async public void CallBackGround()
        {
            await Task.Run(() =>
            {
                ProgramExport.Main(); // Niet Program gebruiken
            });
        }
    }
}
