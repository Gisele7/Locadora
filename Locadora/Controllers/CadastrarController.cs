using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers
{
    public class CadastrarController : Controller
    {
        LocadoraContext locadoraContext;

        public CadastrarController()
        {
            locadoraContext = new LocadoraContext();
        }
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
       
        public ActionResult Cadastrar(Logins logins)
        {

            locadoraContext.Logins.Add(logins);
            locadoraContext.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
