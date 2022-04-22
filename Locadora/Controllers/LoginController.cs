using Microsoft.AspNetCore.Mvc;

namespace Locadora.Controllers
{
    public class LoginController : Controller
    {
        LocadoraContext locadoraContext;

        public void Setup()
        {
            locadoraContext = new LocadoraContext();
        }
        public IActionResult Index()
        {
            return View();
        }
        

        [HttpPost]
        public IActionResult Logar()
        {
            try
            {
                Logins ologin = new Logins();
                locadoraContext.Logins.Add(ologin);
                locadoraContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine("erro ao logar.");

            }
            return Json(new { }); //colocando o retorno com Json, conseguimos fazer personalização nas msgs ou bootstrap tb, usando o DataAnnotation..

        }
        //[HttpPost]
        //public void Login()
        //{
        //    try
        //    {
        //        Logins ologin = new Logins();
        //        locadoraContext.Logins.Add(ologin);
        //        locadoraContext.SaveChanges();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Erro ao logar.");

        //    }
        //}
    }
}
