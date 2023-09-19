using Microsoft.AspNetCore.Mvc;

namespace EP.Srv.Cliente.Api.Controllers
{
    public class PlanoDeContasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
