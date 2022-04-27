using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Controllers
{
   
    public class FilmeController : Controller
    {
        LocadoraContext locadoraContext;
        public FilmeController()
        {
            locadoraContext = new LocadoraContext();
        }
        public IActionResult Index()
        {
            var retorno = locadoraContext.Filmes.Include(x => x.IdcategoriaNavigation).ToList();
            return View(retorno);
            
        }
        public ActionResult Details(int id)
        {
            return View();
        }
        
        public ActionResult Edit(int Id)
        {
            Filmes ofilmes = locadoraContext.Filmes.Find(Id);
            return View(ofilmes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int Id, Filmes ofilmes)
        {
            var oFilmesBanco = locadoraContext.Filmes.Find(Id);
            oFilmesBanco.Nome = ofilmes.Nome;
            locadoraContext.Entry(oFilmesBanco).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            locadoraContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                   return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Filmes ofilmes)
        {
            locadoraContext.Filmes.Add(ofilmes);
            locadoraContext.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
