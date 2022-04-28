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
            //AsNoTracking nao coloca o obj no contexto
            var retorno = locadoraContext.Filmes.Include(x => x.IdcategoriaNavigation).AsNoTracking();
            return View(retorno);
            
        }
        public ActionResult Details(int Id)
        {
            Filmes ofilmes = locadoraContext.Filmes.Find(Id);
            return View(ofilmes);
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
            Filmes oFilmes = locadoraContext.Filmes.Find(id);
            return View(oFilmes);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Filmes oFilmes)
        {
            var oFilmesBanco = locadoraContext.Filmes.Find(id);
            oFilmesBanco.Nome = oFilmes.Nome;
            locadoraContext.Entry(oFilmesBanco).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            locadoraContext.SaveChanges();
            return RedirectToAction("Idenx");
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
