using Microsoft.AspNetCore.Mvc;

namespace EP.Srv.Cliente.Api.Controllers
{
    public class CentroDeCustosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
