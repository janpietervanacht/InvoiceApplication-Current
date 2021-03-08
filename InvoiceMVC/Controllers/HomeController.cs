using InvoiceMVC.Asynchronous;
using InvoiceMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace InvoiceMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Index View = hoofdview van controller 'Home'
            // bevat knoppen (@Html.ActionLinks) die naar andere controllers / actions wijzen
            return View();
        }

        public IActionResult StartExport()
        {
            var asyncProcesses = new ASyncProcesses();
            asyncProcesses.CallBackGround();
            return RedirectToAction("Index");
        }   



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
