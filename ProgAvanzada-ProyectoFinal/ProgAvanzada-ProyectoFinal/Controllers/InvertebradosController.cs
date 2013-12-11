using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProgAvanzada_ProyectoFinal.Models;

namespace ProgAvanzada_ProyectoFinal.Controllers
{
    public class InvertebradosController : Controller
    {
        private MagnaEnciclopediaAnimalTurboEntities db = new MagnaEnciclopediaAnimalTurboEntities();

        //
        // GET: /Invertebrados/

        public ActionResult Index()
        {
            var invertebrados = db.Invertebrados.Include(i => i.Habitat).Include(i => i.TipoReproduccion).Include(i => i.TipoAlimentacion).Include(i => i.TipoRespiracion).Include(i => i.TipoSimetria).Include(i => i.TipoTejido);
            return View(invertebrados.ToList());
        }

        //
        // GET: /Invertebrados/Details/5

        public ActionResult Details(int id = 0)
        {
            Invertebrados invertebrados = db.Invertebrados.Find(id);
            if (invertebrados == null)
            {
                return HttpNotFound();
            }
            return View(invertebrados);
        }

        //
        // GET: /Invertebrados/Create

        public ActionResult Create()
        {
            ViewBag.IdHabitat = new SelectList(db.Habitat, "IdHabitat", "Nombre");
            ViewBag.IdTipoReproduccion = new SelectList(db.TipoReproduccion, "IdTipoReproduccion", "Nombre");
            ViewBag.IdTipoAlimentacion = new SelectList(db.TipoAlimentacion, "IdTipoAlimentacion", "Nombre");
            ViewBag.IdTipoRespiracion = new SelectList(db.TipoRespiracion, "IdTipoRespiracion", "Nombre");
            ViewBag.IdTipoSimetria = new SelectList(db.TipoSimetria, "IdTipoSimetria", "Nombre");
            ViewBag.IdTipoTejido = new SelectList(db.TipoTejido, "IdTipoTejido", "Nombre");
            return View();
        }

        //
        // POST: /Invertebrados/Create

        [HttpPost]
        public ActionResult Create(Invertebrados invertebrados)
        {
            if (ModelState.IsValid)
            {
                db.Invertebrados.Add(invertebrados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdHabitat = new SelectList(db.Habitat, "IdHabitat", "Nombre", invertebrados.IdHabitat);
            ViewBag.IdTipoReproduccion = new SelectList(db.TipoReproduccion, "IdTipoReproduccion", "Nombre", invertebrados.IdTipoReproduccion);
            ViewBag.IdTipoAlimentacion = new SelectList(db.TipoAlimentacion, "IdTipoAlimentacion", "Nombre", invertebrados.IdTipoAlimentacion);
            ViewBag.IdTipoRespiracion = new SelectList(db.TipoRespiracion, "IdTipoRespiracion", "Nombre", invertebrados.IdTipoRespiracion);
            ViewBag.IdTipoSimetria = new SelectList(db.TipoSimetria, "IdTipoSimetria", "Nombre", invertebrados.IdTipoSimetria);
            ViewBag.IdTipoTejido = new SelectList(db.TipoTejido, "IdTipoTejido", "Nombre", invertebrados.IdTipoTejido);
            return View(invertebrados);
        }

        //
        // GET: /Invertebrados/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Invertebrados invertebrados = db.Invertebrados.Find(id);
            if (invertebrados == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdHabitat = new SelectList(db.Habitat, "IdHabitat", "Nombre", invertebrados.IdHabitat);
            ViewBag.IdTipoReproduccion = new SelectList(db.TipoReproduccion, "IdTipoReproduccion", "Nombre", invertebrados.IdTipoReproduccion);
            ViewBag.IdTipoAlimentacion = new SelectList(db.TipoAlimentacion, "IdTipoAlimentacion", "Nombre", invertebrados.IdTipoAlimentacion);
            ViewBag.IdTipoRespiracion = new SelectList(db.TipoRespiracion, "IdTipoRespiracion", "Nombre", invertebrados.IdTipoRespiracion);
            ViewBag.IdTipoSimetria = new SelectList(db.TipoSimetria, "IdTipoSimetria", "Nombre", invertebrados.IdTipoSimetria);
            ViewBag.IdTipoTejido = new SelectList(db.TipoTejido, "IdTipoTejido", "Nombre", invertebrados.IdTipoTejido);
            return View(invertebrados);
        }

        //
        // POST: /Invertebrados/Edit/5

        [HttpPost]
        public ActionResult Edit(Invertebrados invertebrados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(invertebrados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdHabitat = new SelectList(db.Habitat, "IdHabitat", "Nombre", invertebrados.IdHabitat);
            ViewBag.IdTipoReproduccion = new SelectList(db.TipoReproduccion, "IdTipoReproduccion", "Nombre", invertebrados.IdTipoReproduccion);
            ViewBag.IdTipoAlimentacion = new SelectList(db.TipoAlimentacion, "IdTipoAlimentacion", "Nombre", invertebrados.IdTipoAlimentacion);
            ViewBag.IdTipoRespiracion = new SelectList(db.TipoRespiracion, "IdTipoRespiracion", "Nombre", invertebrados.IdTipoRespiracion);
            ViewBag.IdTipoSimetria = new SelectList(db.TipoSimetria, "IdTipoSimetria", "Nombre", invertebrados.IdTipoSimetria);
            ViewBag.IdTipoTejido = new SelectList(db.TipoTejido, "IdTipoTejido", "Nombre", invertebrados.IdTipoTejido);
            return View(invertebrados);
        }

        //
        // GET: /Invertebrados/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Invertebrados invertebrados = db.Invertebrados.Find(id);
            if (invertebrados == null)
            {
                return HttpNotFound();
            }
            return View(invertebrados);
        }

        //
        // POST: /Invertebrados/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Invertebrados invertebrados = db.Invertebrados.Find(id);
            db.Invertebrados.Remove(invertebrados);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}