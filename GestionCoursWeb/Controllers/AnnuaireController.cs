using GestionCours.Model;
using Microsoft.AspNetCore.Mvc;

namespace GestionCoursWeb.Controllers
{
    public class AnnuaireController : Controller
    {
        private readonly AnnuaireContext _context ;

        public AnnuaireController(AnnuaireContext context) //on laisse .Net se débrouiller à instancier se contexte
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Diplome> diplomes = _context.Diplomes.OrderBy(d =>d.Niveau).ThenBy(d=>d.Nom).ToList();
            return View(diplomes);
        }

        public IActionResult Create()
        {           
            return View();
        }

        [HttpPost]
        public IActionResult Create(Diplome diplome)
        {
            if(_context.Diplomes.Any(d=>d.Code.Equals(diplome.Code)))
            {
                ViewBag.Erreur = "Ce diplôme existe déjà. ";
                return View(diplome);
            }

            _context.Diplomes.Add(diplome);
            _context.SaveChanges();
            return RedirectToAction("Index");
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
            Diplome diplomeExiste = _context.Diplomes.FirstOrDefault(d => d.Code.Equals(diplome.Code));
            if (diplomeExiste == null)
            {
                ViewBag.Erreur = "Ce diplôme n'existe pas. ";
                return View(diplome);
            }

            diplomeExiste.Nom= diplome.Nom; 
            diplomeExiste.Niveau = diplome.Niveau;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
