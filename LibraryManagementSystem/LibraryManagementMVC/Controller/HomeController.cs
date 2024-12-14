using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementMVC.Controller
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
