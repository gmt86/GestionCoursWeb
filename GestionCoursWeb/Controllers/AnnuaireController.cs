using GestionCours.Model;
using Microsoft.AspNetCore.Mvc;

namespace GestionCoursWeb.Controllers
{
    public class AnnuaireController : Controller
    {
        private readonly AnnuaireContext _context = new AnnuaireContext();
        public IActionResult Index()
        {
            List<Diplome> diplomes = _context.Diplomes.OrderBy(d =>d.Niveau).ThenBy(d=>d.Nom).ToList();
            return View(diplomes);
        }

        public IActionResult Edit(string id)
        {
            Diplome diplome = _context.Diplomes.FirstOrDefault(d => d.Code.Equals(id));
            if (diplome == null)
                return NotFound();
            return View(diplome);
        }

        [HttpPost]
        public IActionResult Edit(Diplome diplome)
        {

            return RedirectToAction("Index");
        }
    }
}
