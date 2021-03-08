using OutgoingExports.Managers;

namespace OutgoingExports
{
    //public class Program DIT WAS DE ORIGINELE CODE
    public static class ProgramExport // Veranderd, HIERDOOR aanroepbaar geworden vanuit MVC
    {
        // private static void Main(string[] args) // Dit was de originele code
        public static void Main()
        {
            // Opstarten Dependency Injection en processen
            // is verplaatst naar een non-static method: StartBackGround(). 
            var outgoingManager = new StartManager(); // DI moet je binnen StartManager regelen 
            outgoingManager.StartBackGround();
        }

    }
}
