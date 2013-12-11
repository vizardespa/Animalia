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
    public class VertebradosController : Controller
    {
        private MagnaEnciclopediaAnimalTurboEntities db = new MagnaEnciclopediaAnimalTurboEntities();

        //
        // GET: /Vertebrados/

        public ActionResult Index()
        {
            var vertebrados = db.Vertebrados.Include(v => v.EstructuraPiel).Include(v => v.Habitat).Include(v => v.TipoAlimentacion).Include(v => v.TipoExtremidad).Include(v => v.TipoReproduccion).Include(v => v.TipoRespiracion).Include(v => v.TipoSangre);
            return View(vertebrados.ToList());
        }

        //
        // GET: /Vertebrados/Details/5

        public ActionResult Details(int id = 0)
        {
            Vertebrados vertebrados = db.Vertebrados.Find(id);
            if (vertebrados == null)
            {
                return HttpNotFound();
            }
            return View(vertebrados);
        }

        //
        // GET: /Vertebrados/Create

        public ActionResult Create()
        {
            ViewBag.IdEstructuraPiel = new SelectList(db.EstructuraPiel, "IdEstructuraPiel", "Nombre");
            ViewBag.IdHabitat = new SelectList(db.Habitat, "IdHabitat", "Nombre");
            ViewBag.IdTipoAlimentacion = new SelectList(db.TipoAlimentacion, "IdTipoAlimentacion", "Nombre");
            ViewBag.IdTipoExtremidad = new SelectList(db.TipoExtremidad, "IdTipoExtremidad", "Nombre");
            ViewBag.IdTipoReproduccion = new SelectList(db.TipoReproduccion, "IdTipoReproduccion", "Nombre");
            ViewBag.IdTipoRespiracion = new SelectList(db.TipoRespiracion, "IdTipoRespiracion", "Nombre");
            ViewBag.IdTipoSangre = new SelectList(db.TipoSangre, "IdTipoSangre", "Nombre");
            return View();
        }

        //
        // POST: /Vertebrados/Create

        [HttpPost]
        public ActionResult Create(Vertebrados vertebrados)
        {
            if (ModelState.IsValid)
            {
                db.Vertebrados.Add(vertebrados);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEstructuraPiel = new SelectList(db.EstructuraPiel, "IdEstructuraPiel", "Nombre", vertebrados.IdEstructuraPiel);
            ViewBag.IdHabitat = new SelectList(db.Habitat, "IdHabitat", "Nombre", vertebrados.IdHabitat);
            ViewBag.IdTipoAlimentacion = new SelectList(db.TipoAlimentacion, "IdTipoAlimentacion", "Nombre", vertebrados.IdTipoAlimentacion);
            ViewBag.IdTipoExtremidad = new SelectList(db.TipoExtremidad, "IdTipoExtremidad", "Nombre", vertebrados.IdTipoExtremidad);
            ViewBag.IdTipoReproduccion = new SelectList(db.TipoReproduccion, "IdTipoReproduccion", "Nombre", vertebrados.IdTipoReproduccion);
            ViewBag.IdTipoRespiracion = new SelectList(db.TipoRespiracion, "IdTipoRespiracion", "Nombre", vertebrados.IdTipoRespiracion);
            ViewBag.IdTipoSangre = new SelectList(db.TipoSangre, "IdTipoSangre", "Nombre", vertebrados.IdTipoSangre);
            return View(vertebrados);
        }

        //
        // GET: /Vertebrados/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Vertebrados vertebrados = db.Vertebrados.Find(id);
            if (vertebrados == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEstructuraPiel = new SelectList(db.EstructuraPiel, "IdEstructuraPiel", "Nombre", vertebrados.IdEstructuraPiel);
            ViewBag.IdHabitat = new SelectList(db.Habitat, "IdHabitat", "Nombre", vertebrados.IdHabitat);
            ViewBag.IdTipoAlimentacion = new SelectList(db.TipoAlimentacion, "IdTipoAlimentacion", "Nombre", vertebrados.IdTipoAlimentacion);
            ViewBag.IdTipoExtremidad = new SelectList(db.TipoExtremidad, "IdTipoExtremidad", "Nombre", vertebrados.IdTipoExtremidad);
            ViewBag.IdTipoReproduccion = new SelectList(db.TipoReproduccion, "IdTipoReproduccion", "Nombre", vertebrados.IdTipoReproduccion);
            ViewBag.IdTipoRespiracion = new SelectList(db.TipoRespiracion, "IdTipoRespiracion", "Nombre", vertebrados.IdTipoRespiracion);
            ViewBag.IdTipoSangre = new SelectList(db.TipoSangre, "IdTipoSangre", "Nombre", vertebrados.IdTipoSangre);
            return View(vertebrados);
        }

        //
        // POST: /Vertebrados/Edit/5

        [HttpPost]
        public ActionResult Edit(Vertebrados vertebrados)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vertebrados).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEstructuraPiel = new SelectList(db.EstructuraPiel, "IdEstructuraPiel", "Nombre", vertebrados.IdEstructuraPiel);
            ViewBag.IdHabitat = new SelectList(db.Habitat, "IdHabitat", "Nombre", vertebrados.IdHabitat);
            ViewBag.IdTipoAlimentacion = new SelectList(db.TipoAlimentacion, "IdTipoAlimentacion", "Nombre", vertebrados.IdTipoAlimentacion);
            ViewBag.IdTipoExtremidad = new SelectList(db.TipoExtremidad, "IdTipoExtremidad", "Nombre", vertebrados.IdTipoExtremidad);
            ViewBag.IdTipoReproduccion = new SelectList(db.TipoReproduccion, "IdTipoReproduccion", "Nombre", vertebrados.IdTipoReproduccion);
            ViewBag.IdTipoRespiracion = new SelectList(db.TipoRespiracion, "IdTipoRespiracion", "Nombre", vertebrados.IdTipoRespiracion);
            ViewBag.IdTipoSangre = new SelectList(db.TipoSangre, "IdTipoSangre", "Nombre", vertebrados.IdTipoSangre);
            return View(vertebrados);
        }

        //
        // GET: /Vertebrados/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Vertebrados vertebrados = db.Vertebrados.Find(id);
            if (vertebrados == null)
            {
                return HttpNotFound();
            }
            return View(vertebrados);
        }

        //
        // POST: /Vertebrados/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Vertebrados vertebrados = db.Vertebrados.Find(id);
            db.Vertebrados.Remove(vertebrados);
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