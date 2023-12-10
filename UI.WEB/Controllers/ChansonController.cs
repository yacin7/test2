using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.WEB.Controllers
{
    public class ChansonController : Controller
    {
        IChansonService cs;
        IArtisteService ar;

        public ChansonController(IChansonService cs, IArtisteService ar)
        {
            this.cs = cs;
            this.ar = ar;
        }


        // GET: ChansonController
        public ActionResult Index()
        {
            return View(cs.GetMany());
        }

        // GET: ChansonController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ChansonController/Create
        public ActionResult Create()
        {
            ViewBag.lsArtiste = new SelectList(ar.GetMany(), "ArtisteId", "Information");
            return View();
        }

        // POST: ChansonController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Chanson collection)
        {
            try
            {
                cs.Add(collection);
                cs.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ChansonController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ChansonController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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

        // GET: ChansonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ChansonController/Delete/5
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
    }
}
