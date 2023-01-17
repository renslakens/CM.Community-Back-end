using Microsoft.AspNetCore.Mvc;

namespace CM.Community_Back_end.Services {
    public class configureServices : Controller {
        public IActionResult Index() {
            return View();
        }
    }
}
